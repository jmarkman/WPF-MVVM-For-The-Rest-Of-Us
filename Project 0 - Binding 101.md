# Project 0: Binding 101, or Introduction to Binding

The core takeaway of MVVM is that by expending effort early on by splitting your application into independent parts, you make it easier for yourself and others in the future to modify the visual appearance or the underlying logic of your application. For me, a massive hurdle in learning MVVM was being able to connect the dots from a rudimentary example to a small application with several moving parts.

At an absolutely basic level, a WPF MVVM application can be broken into just two parts: a View and a ViewModel. The view is what the user of the program will see on their monitor, while the ViewModel is where most of the code-based magic takes place. Don't worry about Models just yet; MVVM wouldn't be anything without them, but for the utmost barebones example, we only need a View and a ViewModel.

# Lay The Foundation: Create a View and a ViewModel

Start out by creating a new WPF project in Visual Studio and call it `IntroToBinding`. Once Visual Studio finishes setting up the project, open the `MainWindow.xaml` file and add a `TextBlock` to the grid of the `MainWindow` file:

```xml
<Grid>
    <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Text="Hello World" />
</Grid>
```

Once you've got that added, build the project. If it builds successfully, run it in debug mode to verify that the GUI that pops up has the words "Hello World" in the center. If it runs successfully, you're good to go; always good to make sure.

Now you'll add an accompanying ViewModel to the application. Create a new folder in the project and name it `ViewModel`; as you might have guessed, the ViewModel will call this folder home. Something you should get into the habit of doing is creating explicit folders for where your code will live, as it will strengthen the "separation of concerns" idea behind MVVM in your mind. 

Next, create a class in that folder called `DemoViewModel` and make sure that this class implements the `INotifyPropertyChanged` interface. 

```csharp
public class DemoViewModel : INotifyPropertyChanged
{

}
```
Of course, it's no good to attach an interface to a class and not implement it, so you'll need to build this out from the top. Start by adding a private field for some text:

```csharp
public class DemoViewModel : INotifyPropertyChanged
{
    private string _text;
}
```
Then create a public field named `PropertyChanged`. If you let Visual Studio implement the interface for you, it will create the following:
```csharp
using System.ComponentModel;

public class DemoViewModel : INotifyPropertyChanged
{
    private string _text;

    public event PropertyChangedEventHandler PropertyChanged;
}
```
Add a constructor...
```csharp
using System.ComponentModel;

public class DemoViewModel : INotifyPropertyChanged
{
    private string _text;

    public event PropertyChangedEventHandler PropertyChanged;

    public DemoViewModel
    {
        
    }
}
```
In order to fully implement the `INotifyPropertyChanged` interface, you'll need to create a method called `OnPropertyChanged`. 
```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DemoViewModel : INotifyPropertyChanged
{
    private string _text;

    public event PropertyChangedEventHandler PropertyChanged;

    public DemoViewModel()
    {

    }

    // [CallerMemberName] allows for some more robust code later on
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
Implementing this method (and in turn, the rest of the `INotifyPropertyChanged` interface) allows the bindings you define in your XAML to stay synchronized with any C# class the interface happens to be implemented on  [(Erik Dietrich, 2011)](https://daedtech.com/wpf-and-notifying-property-change/).

Finally, you'll need to create a backing field that leverages the `OnPropertyChanged` method. 
```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class DemoViewModel : INotifyPropertyChanged
{
    private string _text;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

    public DemoViewModel()
    {

    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
This backing field is comprised of a traditional "getter", which will return the value within the `_text` variable, and a "setter" which looks a little different than what you might be used to. The setter leverages a C# keyword called `value`, which represents any given value that is being referenced from the outside, and it calls the `OnPropertyChanged` method, supplying the name of the backing field as a parameter. Normally, the name of the field would have to be supplied as a string literal, but the usage of `[CallerMemberName]` in `OnPropertyChanged` allows you to simply pass `nameof(Text)` as a parameter and let the compiler handle the rest.

There! The ViewModel is built out!

# Let's Start Binding!

Now that you've established the project, you'll bind some XAML to your ViewModel. Navigate back to your `MainWindow` XAML file, and locate the TextBlock element you created.