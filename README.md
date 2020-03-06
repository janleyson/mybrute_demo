# Chryse - Unity Dev Exam

## Requirements

*  Fork this repository.
*  Create a demo clone of '[MyBrute](http://mybrute.com/)' using the minimal MVC framework inside the Framework/MVC folder.
*  Game loop + winning conditions should work properly.
*  Bonus points for animated characters (feel free to download free-to-use assets).
*  Finish the project within 1 week after forking.

## Conventions

* Keep your git commits as small as you can
* All sprites go to Game/Sprites folder
* All animations go to Game/Animations folder
* All meshes go to Game/Meshes folder
* Folders use PascalCase (e.g. ThisIsAFolder, Character/Head/EyesAndNose)
* Always use *this* when referencing local variables

Classes use PascalCase while fields use camelCase

```
class Character {
    private string label;
}
```

Properties use PascalCase

```
public string Label 
   get {
        return this.label;
   }
   set {
        this.label = value;
   }
}
```

