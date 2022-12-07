﻿using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrippingApp.ViewModel
{
    public class Cylinder_Control_ViewModel:BaseViewModel.BaseViewModel
    {
        public ICommand XL1_Up_Command { get; set; }
        public ICommand XL1_Down_Command { get; set; }
        public ICommand XL2_Up_Command { get; set; }
        public ICommand XL2_Down_Command { get; set; }
        public ICommand XL3_Up_Command { get; set; }
        public ICommand XL3_Down_Command { get; set; }
        public ICommand XL4_Up_Command { get; set; }
        public ICommand XL4_Down_Command { get; set; }
        public ICommand XL5_Up_Command { get; set; }
        public ICommand XL5_Down_Command { get; set; }
        public ICommand XL6_Up_Command { get; set; }
        public ICommand XL6_Down_Command { get; set; }
        public ICommand XL7_Up_Command { get; set; }
        public ICommand XL7_Down_Command { get; set; }
        public ICommand XL8_Up_Command { get; set; }
        public ICommand XL8_Down_Command { get; set; }
        public ICommand XL9_Up_Command { get; set; }
        public ICommand XL9_Down_Command { get; set; }
        public ICommand XL10_Up_Command { get; set; }
        public ICommand XL10_Down_Command { get; set; }
        public ICommand XL11_Up_Command { get; set; }
        public ICommand XL11_Down_Command { get; set; }
        public ICommand XL12_Up_Command { get; set; }
        public ICommand XL12_Down_Command { get; set; }
        public ICommand XL13_Up_Command { get; set; }
        public ICommand XL13_Down_Command { get; set; }
        public ICommand XL14_Up_Command { get; set; }
        public ICommand XL14_Down_Command { get; set; }


        #region Model Sensor
        private bool _ss1_up;

        public bool SS1_Up
        {
            get { return _ss1_up; }
            set { SetProperty(ref _ss1_up, value, nameof(SS1_Up)); }
        }

        private bool _ss1_down;

        public bool SS1_Down
        {
            get { return _ss1_down; }
            set { SetProperty(ref _ss1_down, value, nameof(SS1_Down)); }
        }

        private bool _ss2_up;

        public bool SS2_Up
        {
            get { return _ss2_up; }
            set { SetProperty(ref _ss2_up, value, nameof(SS2_Up)); }
        }

        private bool _ss2_down;

        public bool SS2_Down
        {
            get { return _ss2_down; }
            set { SetProperty(ref _ss2_down, value, nameof(SS2_Down)); }
        }

        private bool _ss3_up;

        public bool SS3_Up
        {
            get { return _ss3_up; }
            set { SetProperty(ref _ss3_up, value, nameof(SS3_Up)); }
        }

        private bool _ss3_down;

        public bool SS3_Down
        {
            get { return _ss3_down; }
            set { SetProperty(ref _ss3_down, value, nameof(SS3_Down)); }
        }

        private bool _ss4_up;

        public bool SS4_Up
        {
            get { return _ss4_up; }
            set { SetProperty(ref _ss4_up, value, nameof(SS4_Up)); }
        }

        private bool _ss4_down;

        public bool SS4_Down
        {
            get { return _ss4_down; }
            set { SetProperty(ref _ss4_down, value, nameof(SS4_Down)); }
        }

        private bool _ss5_up;

        public bool SS5_Up
        {
            get { return _ss5_up; }
            set { SetProperty(ref _ss5_up, value, nameof(SS5_Up)); }
        }

        private bool _ss5_down;

        public bool SS5_Down
        {
            get { return _ss5_down; }
            set { SetProperty(ref _ss5_down, value, nameof(SS5_Down)); }
        }

        private bool _ss6_up;

        public bool SS6_Up
        {
            get { return _ss6_up; }
            set { SetProperty(ref _ss6_up, value, nameof(SS6_Up)); }
        }

        private bool _ss6_down;

        public bool SS6_Down
        {
            get { return _ss6_down; }
            set { SetProperty(ref _ss6_down, value, nameof(SS6_Down)); }
        }

        private bool _ss7_up;

        public bool SS7_Up
        {
            get { return _ss7_up; }
            set { SetProperty(ref _ss7_up, value, nameof(SS7_Up)); }
        }

        private bool _ss7_down;

        public bool SS7_Down
        {
            get { return _ss7_down; }
            set { SetProperty(ref _ss7_down, value, nameof(SS7_Down)); }
        }

        private bool _ss8_up;

        public bool SS8_Up
        {
            get { return _ss8_up; }
            set { SetProperty(ref _ss8_up, value, nameof(SS8_Up)); }
        }

        private bool _ss8_down;

        public bool SS8_Down
        {
            get { return _ss8_down; }
            set { SetProperty(ref _ss8_down, value, nameof(SS8_Down)); }
        }

        private bool _ss9_up;

        public bool SS9_Up
        {
            get { return _ss9_up; }
            set { SetProperty(ref _ss9_up, value, nameof(SS9_Up)); }
        }

        private bool _ss9_down;

        public bool SS9_Down
        {
            get { return _ss9_down; }
            set { SetProperty(ref _ss9_down, value, nameof(SS9_Down)); }
        }

        private bool _ss10_up;

        public bool SS10_Up
        {
            get { return _ss10_up; }
            set { SetProperty(ref _ss10_up, value, nameof(SS10_Up)); }
        }

        private bool _ss10_down;

        public bool SS10_Down
        {
            get { return _ss10_down; }
            set { SetProperty(ref _ss10_down, value, nameof(SS10_Down)); }
        }

        private bool _ss11_up;

        public bool SS11_Up
        {
            get { return _ss11_up; }
            set { SetProperty(ref _ss11_up, value, nameof(SS11_Up)); }
        }

        private bool _ss11_down;

        public bool SS11_Down
        {
            get { return _ss11_down; }
            set { SetProperty(ref _ss11_down, value, nameof(SS11_Down)); }
        }

        private bool _ss12_up;

        public bool SS12_Up
        {
            get { return _ss12_up; }
            set { SetProperty(ref _ss12_up, value, nameof(SS12_Up)); }
        }

        private bool _ss12_down;

        public bool SS12_Down
        {
            get { return _ss12_down; }
            set { SetProperty(ref _ss12_down, value, nameof(SS12_Down)); }
        }

        private bool _ss13_up;

        public bool SS13_Up
        {
            get { return _ss13_up; }
            set { SetProperty(ref _ss13_up, value, nameof(SS13_Up)); }
        }

        private bool _ss13_down;

        public bool SS13_Down
        {
            get { return _ss13_down; }
            set { SetProperty(ref _ss13_down, value, nameof(SS13_Down)); }
        }

        private bool _ss14_up;

        public bool SS14_Up
        {
            get { return _ss14_up; }
            set { SetProperty(ref _ss14_up, value, nameof(SS14_Up)); }
        }

        private bool _ss14_down;

        public bool SS14_Down
        {
            get { return _ss14_down; }
            set { SetProperty(ref _ss14_down, value, nameof(SS14_Down)); }
        }



        #endregion
        public Cylinder_Control_ViewModel()
        {
            #region XL1
            XL1_Up_Command = new ActionCommand(() =>
            {

            });
            XL1_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL2
            XL2_Up_Command = new ActionCommand(() =>
            {

            });
            XL2_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL3
            XL3_Up_Command = new ActionCommand(() =>
            {

            });
            XL3_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL4
            XL4_Up_Command = new ActionCommand(() =>
            {

            });
            XL4_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL5
            XL5_Up_Command = new ActionCommand(() =>
            {

            });
            XL5_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL6
            XL6_Up_Command = new ActionCommand(() =>
            {

            });
            XL6_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL7
            XL7_Up_Command = new ActionCommand(() =>
            {

            });
            XL7_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL8
            XL8_Up_Command = new ActionCommand(() =>
            {

            });
            XL8_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL9
            XL9_Up_Command = new ActionCommand(() =>
            {

            });
            XL9_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL10
            XL10_Up_Command = new ActionCommand(() =>
            {

            });
            XL10_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL11
            XL11_Up_Command = new ActionCommand(() =>
            {

            });
            XL11_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL12
            XL12_Up_Command = new ActionCommand(() =>
            {

            });
            XL12_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL13
            XL13_Up_Command = new ActionCommand(() =>
            {

            });
            XL13_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion

            #region XL14
            XL14_Up_Command = new ActionCommand(() =>
            {

            });
            XL14_Down_Command = new ActionCommand(() =>
            {

            });
            #endregion




        }
    }
}