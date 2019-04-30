# Project 0: Binding 101, or Introduction to Binding

The core takeaway of MVVM is that by expending effort early on by splitting your application into independent parts, you make it easier for yourself and others in the future to modify the visual appearance or the underlying logic of your application. For me, a massive hurdle in learning MVVM was being able to connect the dots from a rudimentary example to a small application with several moving parts.

At an absolutely basic level, a WPF MVVM application can be broken into just two parts: a View and a ViewModel. The view is what the user of the program will see on their monitor, while the ViewModel is where most of the code-based magic takes place. Don't worry about models just yet.

Start out by creating a new WPF project in Visual Studio and call it `IntroToBinding`. Once Visual Studio finishes setting up the project, we'll start out as simple as possible. Open the `MainWindow.xaml` file and add a `TextBlock` to the grid of the `MainWindow` file:

```xml
<Grid>
    <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Text="Hello World" />
</Grid>
```

Once you've got that added, build the project. If it builds successfully, run it in debug mode to verify that the GUI that pops up has the words "Hello World" in the center. If it runs successfully, we're good to go; always good to make sure.

Now we'll add an accompanying ViewModel to the application. Create a new folder in the project and name it `ViewModel`; as you might have guessed, our ViewModel will call this folder home. Something you should get into the habit of doing is creating explicit folders for where your code will live as it will strengthen the "separation of concerns" idea behind MVVM in your mind. 

Next, create a class in that folder called `DemoViewModel` and make sure that this class implements the `INotifyPropertyChanged` interface.