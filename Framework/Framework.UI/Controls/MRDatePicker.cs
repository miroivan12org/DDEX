﻿using Framework.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.UI.Controls
{
    public partial class MRDatePicker : DateTimePicker, IMREditableControl, IMRControlCollectionParent
    {
        public MRDatePicker()
        {
            InitializeComponent();
        }

        public MRDatePicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        [DefaultValue(false)]
        public bool IgnoreParentsEnabled { get; set; } = false;

        private bool editable = true;
        [DefaultValue(true)]
        public bool Editable
        {
            get
            {
                return editable;
            }
            set
            {
                editable = value;
                Helpers.StaticHelpers.EnableChildren(this);
            }
        }
    }
}
