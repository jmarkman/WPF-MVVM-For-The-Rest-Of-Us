# Project 0: Binding 101

The core takeaway of MVVM is that by expending effort early on by splitting your application into independent parts, you make it easier for yourself and others in the future to modify the visual appearance or the underlying logic of your application. For me, a massive hurdle in learning MVVM was being able to connect the dots from a rudimentary example to a small application with several moving parts.

At an absolutely basic level, a WPF MVVM application is broken into two parts: a View and a ViewModel. The view is what the user of the program will see on their monitor, while the ViewModel is where most of the code-based magic takes place.