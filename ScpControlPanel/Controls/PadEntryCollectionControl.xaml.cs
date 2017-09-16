﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using Bindables;
using ScpControl.Profiler;
using ScpControl.ScpCore;
using ScpControl.Shared.Core;

namespace ScpControlPanel.Controls
{
    /// <summary>
    /// Interaction logic for PadEntryCollectionControl.xaml
    /// </summary>
    public partial class PadEntryCollectionControl : UserControl
    {
        [DependencyProperty]
        public ObservableCollection<PadEntryControl> PadEntryCollection { get; set; }

        public PadEntryCollectionControl()
        {
            InitializeComponent();

            PadEntryCollection = new ObservableCollection<PadEntryControl>();
            PadEntryCollection.CollectionChanged += PadEntryCollectionOnCollectionChanged;
        }

        private void PadEntryCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (PadEntryControl padEntryControl in notifyCollectionChangedEventArgs.NewItems)
            {
                padEntryControl.IsTopPad = (padEntryControl.PadId != DsPadId.One && padEntryControl.PadId != DsPadId.None);
            }
        }
    }
}
