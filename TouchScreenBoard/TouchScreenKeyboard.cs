﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Design;

namespace TouchScreenBoard
{
    public class TouchScreenKeyboard : Window
    {
        #region Property & Variable & Constructor
        private static double _WidthTouchKeyboard = 935;

        private static double _heightTouchKeyboard = 340;

        public static double HeightTouchKeyboard
        {
            get { return _heightTouchKeyboard; }
            set { _heightTouchKeyboard = value; }
        }

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeyboard; }
            set { _WidthTouchKeyboard = value; }

        }
        private static bool _ShiftFlag;

        protected static bool ShiftFlag
        {
            get { return _ShiftFlag; }
            set { _ShiftFlag = value; }
        }

        private static bool _CapsLockFlag;

        protected static bool CapsLockFlag
        {
            get { return TouchScreenKeyboard._CapsLockFlag; }
            set { TouchScreenKeyboard._CapsLockFlag = value; }
        }

        private static Window _InstanceObject;

        private static Brush _PreviousTextBoxBackgroundBrush = null;
        private static Brush _PreviousTextBoxBorderBrush = null;
        private static Thickness _PreviousTextBoxBorderThickness;

        private static Control _CurrentControl;
        public static string TouchScreenText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox)_CurrentControl).Password;
                }
                else return "";


            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox)_CurrentControl).Password = value;
                }


            }

        }

        public static RoutedUICommand CmdTlide = new RoutedUICommand();
        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand CmdMinus = new RoutedUICommand();
        public static RoutedUICommand CmdPlus = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();


        public static RoutedUICommand CmdTab = new RoutedUICommand();
        public static RoutedUICommand CmdQ = new RoutedUICommand();
        public static RoutedUICommand Cmdw = new RoutedUICommand();
        public static RoutedUICommand CmdE = new RoutedUICommand();
        public static RoutedUICommand CmdR = new RoutedUICommand();
        public static RoutedUICommand CmdT = new RoutedUICommand();
        public static RoutedUICommand CmdY = new RoutedUICommand();
        public static RoutedUICommand CmdU = new RoutedUICommand();
        public static RoutedUICommand CmdI = new RoutedUICommand();
        public static RoutedUICommand CmdO = new RoutedUICommand();
        public static RoutedUICommand CmdP = new RoutedUICommand();
        public static RoutedUICommand CmdOpenCrulyBrace = new RoutedUICommand();
        public static RoutedUICommand CmdEndCrultBrace = new RoutedUICommand();
        public static RoutedUICommand CmdOR = new RoutedUICommand();

        public static RoutedUICommand CmdCapsLock = new RoutedUICommand();
        public static RoutedUICommand CmdA = new RoutedUICommand();
        public static RoutedUICommand CmdS = new RoutedUICommand();
        public static RoutedUICommand CmdD = new RoutedUICommand();
        public static RoutedUICommand CmdF = new RoutedUICommand();
        public static RoutedUICommand CmdG = new RoutedUICommand();
        public static RoutedUICommand CmdH = new RoutedUICommand();
        public static RoutedUICommand CmdJ = new RoutedUICommand();
        public static RoutedUICommand CmdK = new RoutedUICommand();
        public static RoutedUICommand CmdL = new RoutedUICommand();
        public static RoutedUICommand CmdColon = new RoutedUICommand();
        public static RoutedUICommand CmdDoubleInvertedComma = new RoutedUICommand();
        public static RoutedUICommand CmdEnter = new RoutedUICommand();

        public static RoutedUICommand CmdShift = new RoutedUICommand();
        public static RoutedUICommand CmdZ = new RoutedUICommand();
        public static RoutedUICommand CmdX = new RoutedUICommand();
        public static RoutedUICommand CmdC = new RoutedUICommand();
        public static RoutedUICommand CmdV = new RoutedUICommand();
        public static RoutedUICommand CmdB = new RoutedUICommand();
        public static RoutedUICommand CmdN = new RoutedUICommand();
        public static RoutedUICommand CmdM = new RoutedUICommand();
        public static RoutedUICommand CmdGreaterThan = new RoutedUICommand();
        public static RoutedUICommand CmdLessThan = new RoutedUICommand();
        public static RoutedUICommand CmdQuestion = new RoutedUICommand();
        public static RoutedUICommand move = new RoutedUICommand();



        public static RoutedUICommand CmdSpaceBar = new RoutedUICommand();
        public static RoutedUICommand CmdClear = new RoutedUICommand();
        public static RoutedUICommand CmdClose = new RoutedUICommand();

        //berk türkçe
        public static RoutedUICommand CmdGg = new RoutedUICommand();
        public static RoutedUICommand CmdUu = new RoutedUICommand();
        public static RoutedUICommand CmdSs = new RoutedUICommand();
        public static RoutedUICommand CmdIi = new RoutedUICommand();
        public static RoutedUICommand CmdOo = new RoutedUICommand();
        public static RoutedUICommand CmdCc = new RoutedUICommand();
        //berk

        Image topBar;
        public TouchScreenKeyboard()
        {
            this.Width = WidthTouchKeyboard;
            this.Height = HeightTouchKeyboard;
            moved = false;
            foreach (Image br in FindVisualChildren<Image>(this))
            {
                if (br.Name == "topBar")
                {
                    this.topBar = br;
                }

            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }
        static TouchScreenKeyboard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TouchScreenKeyboard), new FrameworkPropertyMetadata(typeof(TouchScreenKeyboard)));

            SetCommandBinding();
        }
        #endregion
        #region CommandRelatedCode
        private static void SetCommandBinding()
        {
            CommandBinding CbTlide = new CommandBinding(CmdTlide, RunCommand);
            CommandBinding Cb1 = new CommandBinding(Cmd1, RunCommand);
            CommandBinding Cb2 = new CommandBinding(Cmd2, RunCommand);
            CommandBinding Cb3 = new CommandBinding(Cmd3, RunCommand);
            CommandBinding Cb4 = new CommandBinding(Cmd4, RunCommand);
            CommandBinding Cb5 = new CommandBinding(Cmd5, RunCommand);
            CommandBinding Cb6 = new CommandBinding(Cmd6, RunCommand);
            CommandBinding Cb7 = new CommandBinding(Cmd7, RunCommand);
            CommandBinding Cb8 = new CommandBinding(Cmd8, RunCommand);
            CommandBinding Cb9 = new CommandBinding(Cmd9, RunCommand);
            CommandBinding Cb0 = new CommandBinding(Cmd0, RunCommand);
            CommandBinding CbMinus = new CommandBinding(CmdMinus, RunCommand);
            CommandBinding CbPlus = new CommandBinding(CmdPlus, RunCommand);
            CommandBinding CbBackspace = new CommandBinding(CmdBackspace, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbTlide);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb1);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb2);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb3);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb4);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb5);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb6);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb7);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb8);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb9);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cb0);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbMinus);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbPlus);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbBackspace);


            CommandBinding CbTab = new CommandBinding(CmdTab, RunCommand);
            CommandBinding CbQ = new CommandBinding(CmdQ, RunCommand);
            CommandBinding Cbw = new CommandBinding(Cmdw, RunCommand);
            CommandBinding CbE = new CommandBinding(CmdE, RunCommand);
            CommandBinding CbR = new CommandBinding(CmdR, RunCommand);
            CommandBinding CbT = new CommandBinding(CmdT, RunCommand);
            CommandBinding CbY = new CommandBinding(CmdY, RunCommand);
            CommandBinding CbU = new CommandBinding(CmdU, RunCommand);
            CommandBinding CbI = new CommandBinding(CmdI, RunCommand);
            CommandBinding Cbo = new CommandBinding(CmdO, RunCommand);
            CommandBinding CbP = new CommandBinding(CmdP, RunCommand);
            CommandBinding CbOpenCrulyBrace = new CommandBinding(CmdOpenCrulyBrace, RunCommand);
            CommandBinding CbEndCrultBrace = new CommandBinding(CmdEndCrultBrace, RunCommand);
            CommandBinding CbOR = new CommandBinding(CmdOR, RunCommand);

            CommandBinding CbCapsLock = new CommandBinding(CmdCapsLock, RunCommand);
            CommandBinding CbA = new CommandBinding(CmdA, RunCommand);
            CommandBinding CbS = new CommandBinding(CmdS, RunCommand);
            CommandBinding CbD = new CommandBinding(CmdD, RunCommand);
            CommandBinding CbF = new CommandBinding(CmdF, RunCommand);
            CommandBinding CbG = new CommandBinding(CmdG, RunCommand);
            CommandBinding CbH = new CommandBinding(CmdH, RunCommand);
            CommandBinding CbJ = new CommandBinding(CmdJ, RunCommand);
            CommandBinding CbK = new CommandBinding(CmdK, RunCommand);
            CommandBinding CbL = new CommandBinding(CmdL, RunCommand);
            CommandBinding CbColon = new CommandBinding(CmdColon, RunCommand);
            CommandBinding CbDoubleInvertedComma = new CommandBinding(CmdDoubleInvertedComma, RunCommand);
            CommandBinding CbEnter = new CommandBinding(CmdEnter, RunCommand);

            CommandBinding CbShift = new CommandBinding(CmdShift, RunCommand);
            CommandBinding CbZ = new CommandBinding(CmdZ, RunCommand);
            CommandBinding CbX = new CommandBinding(CmdX, RunCommand);
            CommandBinding CbC = new CommandBinding(CmdC, RunCommand);
            CommandBinding CbV = new CommandBinding(CmdV, RunCommand);
            CommandBinding CbB = new CommandBinding(CmdB, RunCommand);
            CommandBinding CbN = new CommandBinding(CmdN, RunCommand);
            CommandBinding CbM = new CommandBinding(CmdM, RunCommand);
            CommandBinding CbGreaterThan = new CommandBinding(CmdGreaterThan, RunCommand);
            CommandBinding CbLessThan = new CommandBinding(CmdLessThan, RunCommand);
            CommandBinding CbQuestion = new CommandBinding(CmdQuestion, RunCommand);
            CommandBinding Movve = new CommandBinding(move, RunCommand);



            CommandBinding CbSpaceBar = new CommandBinding(CmdSpaceBar, RunCommand);
            CommandBinding CbClear = new CommandBinding(CmdClear, RunCommand);
            CommandBinding CbClose = new CommandBinding(CmdClose, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbTab);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbQ);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cbw);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbE);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbR);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbT);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbY);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbU);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbI);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Cbo);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbP);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbOpenCrulyBrace);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbEndCrultBrace);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbOR);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbCapsLock);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbA);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbS);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbD);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbF);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbG);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbH);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbJ);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbK);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbL);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbColon);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbDoubleInvertedComma);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbEnter);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbShift);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbZ);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), Movve);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbX);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbC);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbV);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbB);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbN);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbM);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbGreaterThan);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbLessThan);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbQuestion);



            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbSpaceBar);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbClear);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbClose);

            //berk türkçe
            CommandBinding CbGg = new CommandBinding(CmdGg, RunCommand);
            CommandBinding CbUu = new CommandBinding(CmdUu, RunCommand);
            CommandBinding CbSS = new CommandBinding(CmdSs, RunCommand);
            CommandBinding CbIi = new CommandBinding(CmdIi, RunCommand);
            CommandBinding CbOo = new CommandBinding(CmdOo, RunCommand);
            CommandBinding CbCc = new CommandBinding(CmdCc, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbGg);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbUu);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbSS);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbIi);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbOo);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeyboard), CbCc);
            //berk
        }
        private static bool IsRunning = false;
        static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {
            IsRunning = true;
            string result = "";
            if (e.Command == CmdTlide)  //First Row
            {


                if (!ShiftFlag)
                {
                    result = "`";
                }
                else
                {
                    result = "~";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == Cmd1)
            {
                if (!ShiftFlag)
                {
                    result = "1";
                }
                else
                {
                    result = "!";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd2)
            {
                if (!ShiftFlag)
                {
                    result = "2";
                }
                else
                {
                    result = "@";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd3)
            {
                if (!ShiftFlag)
                {
                    result = "3";
                }
                else
                {
                    result = "#";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd4)
            {
                if (!ShiftFlag)
                {
                    result = "4";
                }
                else
                {
                    result = "$";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd5)
            {
                if (!ShiftFlag)
                {
                    result = "5";
                }
                else
                {
                    result = "%";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd6)
            {
                if (!ShiftFlag)
                {
                    result = "6";
                }
                else
                {
                    result = "^";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd7)
            {
                if (!ShiftFlag)
                {
                    result = "7";
                }
                else
                {
                    result = "&";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd8)
            {
                if (!ShiftFlag)
                {
                    result = "8";
                }
                else
                {
                    result = "*";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd9)
            {
                if (!ShiftFlag)
                {
                    result = "9";
                }
                else
                {
                    result = "(";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == Cmd0)
            {
                if (!ShiftFlag)
                {
                    result = "0";
                }
                else
                {
                    result = ")";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdMinus)
            {
                if (!ShiftFlag)
                {
                    result = "-";
                }
                else
                {
                    result = "_";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdPlus)
            {
                if (!ShiftFlag)
                {
                    result = "=";
                }
                else
                {
                    result = "+";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdBackspace)
            {
                IsRunning = true;
                if (SelectionStart > 0)
                {
                    if (TouchScreenKeyboard.SelectedText.Length > 0)
                    {
                        TouchScreenKeyboard.TouchScreenText =
                            TouchScreenKeyboard.TouchScreenText.Remove(SelectionStart, SelectedText.Length);
                        SelectedText = "";
                    }
                    else
                    {
                        TouchScreenKeyboard.TouchScreenText = TouchScreenKeyboard.TouchScreenText.Remove(SelectionStart - 1, 1);
                        --SelectionStart;
                        if (SelectionStart < 0) SelectionStart = 0;
                    }
                }
                IsRunning = false;
            }
            else if (e.Command == CmdTab)  //Second Row
            {
                result = "     ";
            }
            else if (e.Command == CmdQ)
            {
                AddKeyBoardINput('Q');
            }
            else if (e.Command == Cmdw)
            {
                AddKeyBoardINput('w');
            }
            else if (e.Command == CmdE)
            {
                AddKeyBoardINput('E');
            }
            else if (e.Command == CmdR)
            {
                AddKeyBoardINput('R');
            }
            else if (e.Command == CmdT)
            {
                AddKeyBoardINput('T');
            }
            else if (e.Command == CmdY)
            {
                AddKeyBoardINput('Y');
            }
            else if (e.Command == CmdU)
            {
                AddKeyBoardINput('U');

            }
            else if (e.Command == CmdI)
            {
                AddKeyBoardINput('I');
            }
            else if (e.Command == CmdO)
            {
                AddKeyBoardINput('O');
            }
            else if (e.Command == CmdP)
            {
                AddKeyBoardINput('P');
            }
            else if (e.Command == CmdOpenCrulyBrace)
            {
                if (!ShiftFlag)
                {
                    result = "[";
                }
                else
                {
                    result = "{";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdEndCrultBrace)
            {
                if (!ShiftFlag)
                {
                    result = "]";
                }
                else
                {
                    result = "}";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdOR)
            {
                if (!ShiftFlag)
                {
                    result = @"\";
                }
                else
                {
                    result = "|";
                    ShiftFlag = false;
                }
            }
            else if (e.Command == CmdCapsLock)  ///Third ROw
            {

                if (!CapsLockFlag)
                {
                    CapsLockFlag = true;
                }
                else
                {
                    CapsLockFlag = false;

                }
            }
            else if (e.Command == CmdA)
            {
                AddKeyBoardINput('A');
            }
            else if (e.Command == CmdS)
            {
                AddKeyBoardINput('S');
            }
            else if (e.Command == CmdD)
            {
                AddKeyBoardINput('D');
            }
            else if (e.Command == CmdF)
            {
                AddKeyBoardINput('F');
            }
            else if (e.Command == CmdG)
            {
                AddKeyBoardINput('G');
            }
            else if (e.Command == CmdH)
            {
                AddKeyBoardINput('H');
            }
            else if (e.Command == CmdJ)
            {
                AddKeyBoardINput('J');
            }
            else if (e.Command == CmdK)
            {
                AddKeyBoardINput('K');
            }
            else if (e.Command == CmdL)
            {
                AddKeyBoardINput('L');

            }
            else if (e.Command == CmdColon)
            {
                if (!ShiftFlag)
                {
                    result = ";";
                }
                else
                {
                    result = ":";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdDoubleInvertedComma)
            {
                if (!ShiftFlag)
                {
                    result = "'";
                }
                else
                {
                    result = Char.ConvertFromUtf32(34);
                    ShiftFlag = false;
                }


            }
            else if (e.Command == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //System.Windows.Input.Keyboard.ClearFocus();
                SelectionStart = TouchScreenKeyboard.TouchScreenText.Length;
                SelectedText = "";
            }
            else if (e.Command == CmdShift) //Fourth Row
            {

                ShiftFlag = true; ;


            }
            else if (e.Command == CmdZ)
            {
                AddKeyBoardINput('Z');

            }
            else if (e.Command == move)
            {
                AddKeyBoardINput('Z');
            }
            else if (e.Command == CmdX)
            {
                AddKeyBoardINput('X');

            }
            else if (e.Command == CmdC)
            {
                AddKeyBoardINput('C');

            }
            else if (e.Command == CmdV)
            {
                AddKeyBoardINput('V');

            }
            else if (e.Command == CmdB)
            {
                AddKeyBoardINput('B');

            }
            else if (e.Command == CmdN)
            {
                AddKeyBoardINput('N');

            }
            else if (e.Command == CmdM)
            {
                AddKeyBoardINput('M');

            }
            else if (e.Command == CmdLessThan)
            {
                if (!ShiftFlag)
                {
                    result = ",";
                }
                else
                {
                    result = "<";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdGreaterThan)
            {
                if (!ShiftFlag)
                {
                    result = ".";
                }
                else
                {
                    result = ">";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdQuestion)
            {
                if (!ShiftFlag)
                {
                    result = "/";
                }
                else
                {
                    result = "?";
                    ShiftFlag = false;
                }

            }
            else if (e.Command == CmdSpaceBar)//Last row
            {

                result = " ";
            }
            else if (e.Command == CmdClear)//Last row
            {
                TouchScreenKeyboard.TouchScreenText = "";
                SelectionStart = 0;
                SelectedText = "";
            }
            else if (e.Command == CmdClose)
            {
                OnLostFocus(_CurrentControl, null);
            }
            else if (e.Command == CmdGg)    //berk türkçe başladı
            {
                AddKeyBoardINput('Ğ');
            }
            else if (e.Command == CmdUu)
            {
                AddKeyBoardINput('Ü');
            }
            else if (e.Command == CmdSs)
            {
                AddKeyBoardINput('Ş');
            }
            else if (e.Command == CmdIi)
            {
                AddKeyBoardINput('İ');
            }
            else if (e.Command == CmdOo)
            {
                AddKeyBoardINput('Ö');
            }
            else if (e.Command == CmdCc)    //türkçe karakter bitti
            {
                AddKeyBoardINput('Ç');
            }
            AddResult(result);
            IsRunning = false;
        }
        public ICommand CycleStartButtonBorder
        {
            get
            {
                return new RelayCommand(o =>
                {

                    AddKeyBoardINput('c');
                }, o => true);
            }
        }
        #endregion
        #region Main Functionality
        private static void AddKeyBoardINput(char input)
        {
            string result = "";
            if (CapsLockFlag)
            {
                if (ShiftFlag)
                {
                    result = char.ToLower(input).ToString();
                    ShiftFlag = false;

                }
                else
                {
                    result = char.ToUpper(input).ToString();
                }
            }
            else
            {
                if (!ShiftFlag)
                {
                    result = char.ToLower(input).ToString();
                }
                else
                {
                    result = char.ToUpper(input).ToString();
                    ShiftFlag = false;
                }
            }
            AddResult(result);
        }
        private static void AddResult(string result)
        {
            IsRunning = true;
            if (_CurrentControl != null)
            {
                if (_CurrentControl is TextBox)
                {
                    TextBox tb = (TextBox)_CurrentControl;
                    if (SelectedText == null)
                    {
                        SelectedText = "";
                        SelectionStart = tb.Text.Length;
                    }
                    if (TouchScreenKeyboard.SelectedText.Length > 0)
                    {
                        TouchScreenKeyboard.TouchScreenText =
                            TouchScreenKeyboard.TouchScreenText.Remove(tb.SelectionStart, tb.SelectedText.Length);
                    }
                    if (SelectionStart > TouchScreenKeyboard.TouchScreenText.Length) 
                        SelectionStart = TouchScreenKeyboard.TouchScreenText.Length;
                    TouchScreenKeyboard.TouchScreenText =
                        TouchScreenKeyboard.TouchScreenText.Insert(SelectionStart, result);
                    if(result!="")++SelectionStart;
                }
                else if(_CurrentControl is PasswordBox)
                {
                    PasswordBox tb = (PasswordBox)_CurrentControl;
                    if (TouchScreenKeyboard.TouchScreenText == "") SelectionStart = 0;
                    TouchScreenKeyboard.TouchScreenText =
                        TouchScreenKeyboard.TouchScreenText.Insert(SelectionStart, result);
                    if (result != "") ++SelectionStart;
                }
            }
            IsRunning = false;
        }
        private static int ci;

        private static void syncchild()
        {
            try
            {
                if (_CurrentControl != null && _InstanceObject != null)
                {

                    Point virtualpoint = new Point(0, _CurrentControl.ActualHeight + 3);
                    Point Actualpoint = _CurrentControl.PointToScreen(virtualpoint);

                    if (WidthTouchKeyboard + Actualpoint.X > SystemParameters.VirtualScreenWidth)
                    {
                        double difference = WidthTouchKeyboard + Actualpoint.X - SystemParameters.VirtualScreenWidth;
                        _InstanceObject.Left = Actualpoint.X - difference;
                    }
                    else if (!(Actualpoint.X > 1))
                    {
                        _InstanceObject.Left = 1;
                    }
                    else
                    {
                        _InstanceObject.Left = Actualpoint.X;
                    }

                    if (HeightTouchKeyboard + Actualpoint.Y > SystemParameters.VirtualScreenHeight)
                    {
                        _InstanceObject.Top = _CurrentControl.PointToScreen(new Point(0, 0)).Y - HeightTouchKeyboard - 3;
                    }
                    else
                    {
                        _InstanceObject.Top = Actualpoint.Y;
                    }

                    _InstanceObject.Show();
                }
            }
            catch (Exception)
            {
                _InstanceObject.Close();
                //throw;
            }

        }

        public static bool GetTouchScreenKeyboard(DependencyObject obj)
        {
            return (bool)obj.GetValue(TouchScreenKeyboardProperty);
        }

        public static void SetTouchScreenKeyboard(DependencyObject obj, bool value)
        {
            obj.SetValue(TouchScreenKeyboardProperty, value);
        }

        public static readonly DependencyProperty TouchScreenKeyboardProperty =
            DependencyProperty.RegisterAttached("TouchScreenKeyboard", typeof(bool), typeof(TouchScreenKeyboard), new UIPropertyMetadata(default(bool), TouchScreenKeyboardPropertyChanged));



        static void TouchScreenKeyboardPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
                if(host is TextBox)
                {
                    ((TextBox)host).SelectionChanged += TouchScreenKeyboard_SelectionChanged;
                }
            }

        }
        static int SelectionStart;
        static string SelectedText;
        private static void TouchScreenKeyboard_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!IsRunning)
            {
                SelectionStart = ((TextBox)sender).SelectionStart;
                SelectedText = ((TextBox)sender).SelectedText;
            }
        }

        static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control host = sender as Control;

            //_PreviousTextBoxBackgroundBrush = host.Background;
            _PreviousTextBoxBorderBrush = host.BorderBrush;
            _PreviousTextBoxBorderThickness = host.BorderThickness;

            //host.Background = Brushes.Cyan;
            host.BorderBrush = Brushes.Blue;
            host.BorderThickness = new Thickness(4);

            _CurrentControl = host;

            if (_InstanceObject == null)
            {
                FrameworkElement ct = host;
                while (ct != null)
                {
                    if (ct is Window)
                    {
                        ((Window)ct).LocationChanged += new EventHandler(TouchScreenKeyboard_LocationChanged);
                        ((Window)ct).Activated += new EventHandler(TouchScreenKeyboard_Activated);
                        ((Window)ct).Deactivated += new EventHandler(TouchScreenKeyboard_Deactivated);
                        break;
                    }
                    ct = (FrameworkElement)ct.Parent;
                }

                if (ct == null)
                {
                    host.GotFocus += new RoutedEventHandler(TouchScreenKeyboard_Activated);
                    host.LostFocus += new RoutedEventHandler(TouchScreenKeyboard_Deactivated);
                }

                _InstanceObject = new TouchScreenKeyboard();
                _InstanceObject.AllowsTransparency = true;
                _InstanceObject.WindowStyle = WindowStyle.None;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.Topmost = true;

                host.LayoutUpdated += new EventHandler(tb_LayoutUpdated);
            }
            if(_CurrentControl is TextBox)
            {
                ((TextBox)_CurrentControl).SelectAll();
            }


        }

        static void TouchScreenKeyboard_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }
        static void TouchScreenKeyboard_Deactivated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        static void TouchScreenKeyboard_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }

        static void TouchScreenKeyboard_Activated(object sender, RoutedEventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }


        static void TouchScreenKeyboard_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }
        static bool moved = false;
        static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            if (!moved)
                syncchild();
        }



        static void OnLostFocus(object sender, RoutedEventArgs e)
        {

            Control host = sender as Control;
            //host.Background = _PreviousTextBoxBackgroundBrush;
            host.BorderBrush = _PreviousTextBoxBorderBrush;
            host.BorderThickness = _PreviousTextBoxBorderThickness;
            if (_InstanceObject != null)
            {
                _InstanceObject.Close();
                _InstanceObject = null;
            }



        }

        #endregion
        #region Drag Window
        public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
            "EnableDrag",
            typeof(bool),
            typeof(EnableDragHelper),
            new PropertyMetadata(default(bool), OnLoaded));

        private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiElement = dependencyObject as UIElement;
            if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
            {
                return;
            }
            if ((bool)dependencyPropertyChangedEventArgs.NewValue == true)
            {
                uiElement.MouseMove += UIElementOnMouseMove;
            }
            else
            {
                uiElement.MouseMove -= UIElementOnMouseMove;
            }

        }

        private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var uiElement = sender as UIElement;
            if (uiElement != null)
            {
                if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
                {
                    DependencyObject parent = uiElement;
                    int avoidInfiniteLoop = 0;
                    // Search up the visual tree to find the first parent window.
                    while ((parent is Window) == false)
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                        avoidInfiniteLoop++;
                        if (avoidInfiniteLoop == 1000)
                        {
                            // Something is wrong - we could not find the parent window.
                            return;
                        }
                    }
                    var window = parent as Window;
                    window.DragMove();
                }
            }
        }

        public static void SetEnableDrag(DependencyObject element, bool value)
        {
            moved = true;
            element.SetValue(EnableDragProperty, value);
        }

        public static bool GetEnableDrag(DependencyObject element)
        {
            return (bool)element.GetValue(EnableDragProperty);
        }
        #endregion
    }
}
