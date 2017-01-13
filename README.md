# OpenEducator
OpenEducator is like an OpenEDX-esque platform that would allow you to create and manage your own online courses hosted on your own web server.

# Why don't I just use OpenEDX then?
While OpenEdx is pretty cool, configuring it is not user friendly at all. The aim of OpenEducator is to make ease of use, management,
and installation a priority. My eventual goal is to make OpenEducator as easy to use and customizable as WordPress (without the horror of PHP).

# Tell me some unique stuff about this.
Alright, here are some planned features:- 

## Customizable Content Types
All pages have certain contents such as a quiz, flashcards, etc. In order to implement your own content type, you can derive from the
Content abstract class which has a property called HTML. Upon calling the render function of this class, the HTML property will be added
to the DOM of the webpage. In a way, it is like React. 

So what's special about this? You can use the whole .NET library and the power of the C# language to set the value of that HTML property. 
As C# is amazingly powerful, there is no limit to what content types you can create.
