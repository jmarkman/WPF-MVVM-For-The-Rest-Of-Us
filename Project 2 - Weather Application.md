# Project 2: Weather Application

A typical "first project" that many novice programmers are recommended is to make an application that can interface with some kind of weather API because of how many topics it can cover at once, specifically API requests, parsing API data, getting user input, and so on. I personally liked the idea of doing something related to the weather to start because it's immediately useful and hits all the previous high notes, so you'll do that too!

[OpenWeatherMap](https://openweathermap.org/) has a free tier for their API. To use it, create a free account on their website and generate a key. We'll be using this key to communicate with their API.

As usual, create a new WPF project in Visual Studio. To keep things simple, name it `WeatherApp`.

## Talking to the API: Separate the Logic from the User Interface

Don't start any work on the UI for this application just yet. Remember, one of MVVM's selling points is that the pattern makes it easy to separate logic and user interface. The code you're about to create will be the ***model*** for your application. The model is the part of your WPF application that houses necessary data and/or business logic. For this program, your model will be an API wrapper: business logic to communicate with a remote API.

