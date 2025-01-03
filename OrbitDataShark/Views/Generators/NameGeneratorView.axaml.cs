using Avalonia.Controls;
using OrbitDataShark.DataGen.Generators.Name;
using OrbitDataShark.Utilities.Convertors;
using OrbitDataShark.ViewModels;
using System;
using System.Linq;

namespace OrbitDataShark.Views.Generators;

public partial class NameGeneratorView : Window
{
    public readonly string[] NameTypeOptions = Enum.GetNames(typeof(NameType));
    public bool ShowGender = true;
    public NameGeneratorView()
    {
        InitializeComponent();
        nType.ItemsSource = NameTypeOptions.Select(x => new ObjectId(Guid.NewGuid(), x));
        nType.SelectedIndex = 0;
    }

    private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        string[] namesWithGender = [NameType.FirstName.ToString(), NameType.LastName.ToString(), NameType.FullName.ToString(), NameType.Prefix.ToString()];
        if (e.AddedItems.Count != 1)
            return;
        var item = ((ObjectId)e.AddedItems[0]).Name;
        ShowGender = namesWithGender.Contains(item);
        if(!ShowGender)
        {
            GenderGrid.Opacity = 0;
            GenderGrid.IsEnabled = false;
        }else
        {
            GenderGrid.Opacity = 100;
            GenderGrid.IsEnabled = true;
        }
    }
}