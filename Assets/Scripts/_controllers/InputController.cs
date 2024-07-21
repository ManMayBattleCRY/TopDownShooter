using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Game
{
    using InputMode = Game.InputSpace.InputControllerReference;
    namespace InputSpace
    {
        public class InputControllerReference : MonoBehaviour
        {
            HashSet<string> ab = new HashSet<string> ();
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
                string ActionName = TranslateAction(InputName, inputType,AddingAction, FixedUpdate);
                if (Actions.ContainsKey(ActionName))
                {
                    Actions[ActionName] += AddingAction;
                }
                else
                {
                    CreateAction(ActionName, InputName, inputType, AddingAction, FixedUpdate);
                }

            }
            public void Dispose(string InputName, InputType inputType, Action RemovingActiong, bool FixedUpdate)
            {
                string ActionName = TranslateAction(InputName, inputType, RemovingActiong, FixedUpdate);
                if (Actions.ContainsKey(ActionName))
                {
                    Actions[ActionName] -= RemovingActiong;
                    if (Actions[ActionName] == null) Actions.Remove(ActionName);
                }
            }




            String TranslateAction(string InputName, InputType inputType,Action action, bool FixedUpdate) 
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

            void CreateAction(string ActionName, string InputName, InputType inputType, Action AddingAction, bool FixedUpdate)
            {
                Actions.TryAdd(ActionName, AddingAction);
                if (!FixedUpdate)
                {
                    switch (inputType)
                    {
                        case InputType.up:
                            UpdateAction += () => { if (Input.GetButtonUp(InputName)) Actions[ActionName]?.Invoke(); };
                            break;
                        case InputType.hold:
                            UpdateAction += () => { if (Input.GetButton(InputName)) Actions[ActionName]?.Invoke(); };
                            break;
                        case InputType.down:
                            UpdateAction += () => { if (Input.GetButtonDown(InputName)) Actions[ActionName]?.Invoke(); };
                            break;
                    }
                }
                else
                {
                    switch (inputType)
                    {
                        case InputType.up:
                            FixedUpdateAction += () => { if (Input.GetButtonUp(InputName)) Actions[ActionName]?.Invoke(); };
                            break;
                        case InputType.hold:
                            FixedUpdateAction += () => { if (Input.GetButton(InputName)) Actions[ActionName]?.Invoke(); };
                            break;
                        case InputType.down:
                            FixedUpdateAction += () => { if (Input.GetButtonDown(InputName)) Actions[ActionName]?.Invoke(); };
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
