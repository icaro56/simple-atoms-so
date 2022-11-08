using System.IO;
using UnityEditor;
using UnityEngine;

namespace SimpleAtoms.Editor
{
    public class SimpleAtomsEditor : EditorWindow
    {
        private float _space = 20f;
        
        private string _relativeDestinationFolder = "Assets/Scripts/NewAtoms/";
        private string _type = "";
        private string _namespace = "";

        private bool _createVariable = true;
        private bool _createEvent = false;
        private bool _createVariableListener = false;
        private bool _createEventListener = false;

        private string _formatedNamespace;
        private string _formatedType;


        [MenuItem("Tools/Simple Atoms/Create New Atom Type")]
        public static void CreateNewAtomType()
        {
            GetWindow<SimpleAtomsEditor>("Simple Atoms Window");
        }

        private void OnGUI()
        {
            GUILayout.Label("Welcome to your very own editor", EditorStyles.largeLabel);
            GUILayout.Label("This is a label with no styles at all. Feel free it experiment with me and leran how to display user interfaces");
            
            GUILayout.Space(_space);

            _relativeDestinationFolder = EditorGUILayout.TextField("Relative Destination Folder", _relativeDestinationFolder);
            _type = EditorGUILayout.TextField("Type", _type);
            _namespace = EditorGUILayout.TextField("Type Namespace", _namespace);

            GUILayout.Space(_space);

            GUILayout.Label("Atoms checked below will be created", EditorStyles.boldLabel);
            _createVariable = EditorGUILayout.Toggle("Create Variable?", _createVariable);
            _createEvent = EditorGUILayout.Toggle("Create Event?", _createEvent);
            _createVariableListener = EditorGUILayout.Toggle("Create Variable Listener?", _createVariableListener);
            _createEventListener = EditorGUILayout.Toggle("Create Event Listener?", _createEventListener);

            if (GUILayout.Button("Create"))
            {
                OnCreateButtonClicked();
            }
        }

        private void OnCreateButtonClicked()
        {
            if (!HasNeededInputFilled())
            {
                Debug.Log("You must to fill _type and relative destination folder");
                return;
            }
            
            if (!IsAnyToggleChecked())
            {
                Debug.Log("You must check at least one of the toggles");
                return;
            }

            CreateFolder();
            SetupPrerequisites();
            CreateVariable();
            CreateEvent();
            CreateVariableListener();
            CreateEventListener();

            Debug.Log("Atoms create successfully!");

            AssetDatabase.Refresh();
        }

        private void CreateFolder()
        {
            if (!_relativeDestinationFolder.EndsWith('/'))
                _relativeDestinationFolder.Insert(_relativeDestinationFolder.Length, "/");

            if (!AssetDatabase.IsValidFolder(_relativeDestinationFolder))
            {
                System.IO.Directory.CreateDirectory(_relativeDestinationFolder);
            }
        }

        private void SetupPrerequisites()
        {
            _formatedNamespace = !string.IsNullOrEmpty(_namespace) ? $"using {_namespace}" : "";
            _formatedType = char.ToUpper(_type[0]) + _type.Substring(1);
        }

        private void CreateVariable()
        {
            if (!_createVariable)
                return;

            string template = $"using UnityEngine;\n\n" +
                            $"namespace SimpleAtoms.Variables\n{{" +
                            $"\n\t{_formatedNamespace}" +
                            $"\n\t[CreateAssetMenu(menuName = \"SimpleAtoms/Variables/{_formatedType}\")]" +
                            $"\n\tpublic class {_formatedType}Variable : BaseVariable<{_type}> {{}} \n}}";

            var filename = $"{_relativeDestinationFolder}{_formatedType}Variable.cs";
            
            File.WriteAllText(filename, template);
        }

        private void CreateEvent()
        {
            if (!_createEvent)
                return;

            string template = $"using UnityEngine;\n\n" +
                            $"namespace SimpleAtoms.Events\n{{" +
                            $"\n\t{_formatedNamespace}" +
                            $"\n\t[CreateAssetMenu(menuName = \"SimpleAtoms/Events/{_formatedType}\")]" +
                            $"\n\tpublic class {_formatedType}Event : BaseEvent<{_type}> {{}} \n}}";

            var filename = $"{_relativeDestinationFolder}{_formatedType}Event.cs";

            File.WriteAllText(filename, template);
        }

        private void CreateVariableListener()
        {
            if (!_createVariableListener)
                return;

            string template = $"using UnityEngine;\n\n" +
                            $"namespace SimpleAtoms.Listeners\n{{" +
                            $"\n\t{_formatedNamespace}" +
                            $"\n\t[CreateAssetMenu(menuName = \"SimpleAtoms/Listener/Variables/{_formatedType}\")]" +
                            $"\n\tpublic class {_formatedType}VariableListener : BaseVariableListener<{_type}> {{}} \n}}";

            var filename = $"{_relativeDestinationFolder}{_formatedType}VariableListener.cs";

            File.WriteAllText(filename, template);
        }

        private void CreateEventListener()
        {
            if (!_createEventListener)
                return;

            string template = $"using UnityEngine;\n\n" +
                            $"namespace SimpleAtoms.Listeners\n{{" +
                            $"\n\t{_formatedNamespace}" +
                            $"\n\t[CreateAssetMenu(menuName = \"SimpleAtoms/Listener/Events/{_formatedType}\")]" +
                            $"\n\tpublic class {_formatedType}EventListener : BaseEventListener<{_type}> {{}} \n}}";

            var filename = $"{_relativeDestinationFolder}{_formatedType}EventListener.cs";

            File.WriteAllText(filename, template);
        }

        private bool HasNeededInputFilled()
        {
            return !string.IsNullOrEmpty(_relativeDestinationFolder) && !string.IsNullOrEmpty(_type);
        }

        private bool IsAnyToggleChecked()
        {
            return _createVariable || _createEvent || _createVariableListener || _createEventListener;
        }
    }
}