# OpenEducator
OpenEducator is a self-hosted learning management system that allows you to create your own custom courses. It is meant to be highly cusomizable and extendable while simultaneously being easy to setup, manage, and use. 

-------
# TODO
1. WYSIWYG Editor for Courses. Currently only supports creation through C#.
2. NoSQL integration/storage. Currently stores files as JSON on server. 
3. Student enrollment/progress storage. 
4. Design that is not absolutely horrible. 

------
## What are Courses?
The structure of a course is as follows:- 
```
Course
[Name, Description, Contents]
    - Chapter
    [Name, Contents]
        - Topic 
        [Name, Contents] 
            - Page 
            [Title, Contents]
            - Page 
            [Title, Contents]
            - Page 
            [Title, Contents]
        - Topic
        [Name, Contents] 
            - Page
            [Title, Contents]
            - Page
            [Title, Contents]
    - Chapter
    [Name, Contents]
        - Topic
        [Name, Contents]
            - Page
            [Title, Contents]
            - Page
            [Title, Contents]
        - Topic
        [Name, Contents]
            - Page
            [Title, Contents]
            - Page
            [Title, Contents]
            - Page
            [Title, Contents]
```

Each course has a list of chapters, which have a list of topics, which have a list of pages.

## The 'Content' type
Each piece of content is an implementation of the abstract class **Content** which requires the derived class to implement a method called Render that returns a string. That string  is directly embedded into the webpage. For example:- 

```csharp
public class ImageContent: Content {
    
    public string Source { get; set; } = "http://www.placehold.it/400x300";

    public ImageContent(string _src){
        Source = _src ?? Source;
    }

    public string Render(){
        return $@"<img src=""{Source}"" />";
    }
}
```

The webpage will call the render function and embed it into the DOM.

## Customization
The **Content** class provides helper functions that enable you to more easily create Content Types. A few of them are:- 
- **Wrap(string domElement, string data, string style, string[] classes, string id, string open)**
This function allows you to create a DOM element and apply classes, styling, etc. if they exist. 
```<domElement style="{style}" classes="{class} {class} .." id="{id}" {open}>{data}<domElement>```

- **Wrap(string domElement, string style, string[] classes, string id, string open)**
This function is similar to **Wrap** but creates a self-closing element which has no innerHtml/data.
```<domElement style="{style}" classes="{class} {class} .." id="{id}" {open} />```

Let's recreate the **ImageContent** class again but with more functionality using the helper functions. 

```csharp
public class ImageContent: Content {
    
    public string Source { get; set; } = "http://www.placehold.it/400x300";

    public ImageContent(string _src){
        Source = _src ?? Source;
    }

    public string Render(){
        return WrapSelfClosing("img", base.Style, base.Classes, base.ID, $@"src=""{Source}""");
    }
}
```
Since you can make custom content types that can be styled in anyway you want, OpenEducator is highly customizable (unlike edX *cough* *cough*).
