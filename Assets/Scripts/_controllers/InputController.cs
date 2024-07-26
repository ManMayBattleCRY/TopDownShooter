using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    namespace InputSpace
    {
        public class InputControllerReference : MonoBehaviour
        {
            HashSet<string> ActionsHashSet = new HashSet<string> ();
            Dictionary<string, Action> Actions = new Dictionary<string, Action>();
            [HideInInspector] public enum InputType
            {
                up,
                down,
                hold
            }

            public static readonly InputType Up = InputType.up;
            public static readonly InputType Down = InputType.down;
            public static readonly InputType Hold = InputType.hold;


            Action UpdateAction = null;
            Action FixedUpdateAction = null;

           



            public void Subscribe(string InputName, InputType inputType, Action AddingAction, bool FixedUpdate)
            {

                string _dictionary = TranslateActionForDictionary(InputName, inputType, FixedUpdate);
                string _Hash = TranslateActionForHashSet(InputName, inputType,AddingAction, FixedUpdate);
                if (ActionsHashSet.Contains(_Hash))
                {
                    Actions[ _dictionary] += AddingAction;
                }
                else
                {
                    if (Actions.ContainsKey(_dictionary))
                    {
                        Actions[_dictionary] += AddingAction;
                        ActionsHashSet.Add(_Hash);
                    }
                    else
                    {
                        CreateAction(InputName, inputType, AddingAction, FixedUpdate);
                    }

                }

            }
            public void Dispose(string InputName, InputType inputType, Action RemovingActiong, bool FixedUpdate)
            {
                string _dictionary = TranslateActionForDictionary(InputName, inputType, FixedUpdate);
                string _Hash = TranslateActionForHashSet(InputName, inputType, RemovingActiong, FixedUpdate);
                if (ActionsHashSet.Contains(_Hash))
                {
                    ActionsHashSet.Remove(_Hash);
                    Actions[_dictionary] -= RemovingActiong;
                    if (Actions[_dictionary] == null) Actions.Remove(_dictionary);
                }
            }




            String TranslateActionForDictionary(string InputName, InputType inputType, bool FixedUpdate) 
            {
                string actionName = null;
                switch (inputType)
                {
                    case InputType.up:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Up";

                        }
                        else
                        {
                            actionName = InputName + "Up" + "FixedUpdate";

                        }
                        break;

                    case InputType.hold:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Hold";
                        }
                        else
                        {
                            actionName = InputName + "Hold" + "FixedUpdate";
                        }
                        break;

                    case InputType.down:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Down";
                        }
                        else
                        {
                            actionName = InputName + "Down" + "FixedUpdate";
                        }
                        break;

                }
                return actionName;

            }


            String TranslateActionForHashSet(string InputName, InputType inputType, Action action, bool FixedUpdate)
            {
                string actionName = null;
                switch (inputType)
                {
                    case InputType.up:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Up" + action;

                        }
                        else
                        {
                            actionName = InputName + "Up" + action + "FixedUpdate";

                        }
                        break;

                    case InputType.hold:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Hold" + action;
                        }
                        else
                        {
                            actionName = InputName + "Hold" + action + "FixedUpdate";
                        }
                        break;

                    case InputType.down:
                        if (!FixedUpdate)
                        {
                            actionName = InputName + "Down" + action;
                        }
                        else
                        {
                            actionName = InputName + "Down" + action + "FixedUpdate";
                        }
                        break;

                }
                return actionName;

            }

            void CreateAction(string InputName, InputType inputType, Action AddingAction, bool FixedUpdate)
            {
                string _dictionary = TranslateActionForDictionary(InputName, inputType, FixedUpdate);
                string _Hash = TranslateActionForHashSet(InputName, inputType, AddingAction, FixedUpdate);
                ActionsHashSet.Add(_Hash);
                Actions.Add(_dictionary, AddingAction);
                if (!FixedUpdate)
                {
                    switch (inputType)
                    {
                        case InputType.up:
                            UpdateAction += () => { if (Input.GetButtonUp(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                        case InputType.hold:
                            UpdateAction += () => { if (Input.GetButton(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                        case InputType.down:
                            UpdateAction += () => { if (Input.GetButtonDown(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                    }
                }
                else
                {
                    switch (inputType)
                    {
                        case InputType.up:
                            FixedUpdateAction += () => { if (Input.GetButtonUp(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                        case InputType.hold:
                            FixedUpdateAction += () => { if (Input.GetButton(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                        case InputType.down:
                            FixedUpdateAction += () => { if (Input.GetButtonDown(InputName)) Actions[_dictionary]?.Invoke(); };
                            break;
                    }
                }
            }



            public static InputControllerReference InputController { get; private set; }
        

            private void Awake()
            {
                if (InputController == null) 
                {
                    InputController = this;
                    DontDestroyOnLoad(this); // проверь на удаление компонента и геймобджекта
                }
                else Destroy(gameObject);
            }

            private void Update()
            {
                UpdateAction?.Invoke();
            }

            private void FixedUpdate()
            {
                FixedUpdateAction?.Invoke();
            }





        }
    }

   
}
