# Project 1: Displaying An Image From A URL

While the previous example was a basic implementation of MVVM, it's where many of the "simple" guides on MVVM stop. Other guides introduce things like Data Access Layers and Viewmodel Locators very early on after demonstrating a basic implementation. Instead of diving way too far into the deep end, you'll build out several projects that introduce a few new features at a time and reinforce what you learned by building out the previous projects.

For this project, you'll create a small application that accepts a URL of an image and displays it using the Image element.

## Build out the View

Any project will have requirements, even a project as simple as this one. What would you expect a user interface designed to take in a URL and output an image to require?

1. Somewhere to input the URL
2. Something that indicates what should be supplied as input
3. Something that displays the image

All of those things are already included in WPF. Load up a new WPF project called `ImageDisplay` and either implement the nodes on your own, or follow along below.

```xml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="10*"/>
    </Grid.RowDefinitions>

    <!-- 
    The XAML nodes have several properties in them now, so you may want to make things a tad clearer by
    spacing them out on new lines rather than having them all on one line.
    -->
    <StackPanel Grid.Row="0" Orientation="Horizontal">
        <TextBlock 
            Text="Image URL" 
            HorizontalAlignment="Center" 
            VerticalAlignment="Center" 
            Margin="5"/>
        <TextBox 
            Text="" 
            Width="500" 
            Height="20"
            Margin="5"/>
    </StackPanel>

    <Image Grid.Row="1" HorizontalAlignment="Center" VerticalAlignment="Center"/>
</Grid>
```

Next, make a folder called `ViewModel` and create a class in it that will become your viewmodel. If you don't remember exactly how to implement it, that's fine, it'll come with time. Feel free to look back at the example you followed previously or the implementation below.