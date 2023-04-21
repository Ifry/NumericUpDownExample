namespace UpDownTest;

using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;

public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainVM();
    }
}

public class MainVM : ObservableObject
{
    private ObservableObject _selectedItem;

    public List<ObservableObject> VMs { get; set; } = new()
    {
        new VM1(), 
        new VM2(),
        new VM3(),
        new VM4(),
        new VM5(),
        new VM6(),
    };

    public ObservableObject SelectedItem
    {
        get => _selectedItem;
        set => SetField(ref _selectedItem, value);
    }
}

public abstract class VMBase : ObservableObject
{
    public abstract string Name { get; }
    public List<Item> Items { get; set; } = new List<Item>(Enumerable.Range(0, 150).Select(i => new Item(i)));

    #region Overrides of Object

    public override string ToString()
    {
        return Name;
    }

    #endregion
}

public class VM1 : VMBase
{
    public override string Name => "Slow switch 1";
}

public class VM2 : VMBase
{
    public override string Name => "Slow switch 2";
}

public class VM3 : VMBase
{
    public override string Name => "Fast switch 1";
}

public class VM4 : VMBase
{
    public override string Name => "Fast switch 2";
}

public class VM5 : VMBase
{
    public override string Name => "Slow switch (without DataGrid) 1";
}

public class VM6 : VMBase
{
    public override string Name => "Slow switch (without DataGrid) 2";
}

public class Item
{
    public Item(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}
