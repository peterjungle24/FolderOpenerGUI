# FolderOpenerGUI
My version of FolderOpener, but now its made with WPF! (unsurprising)

# JSON Format
The `Path.json` is the file responsable for showing the category and the path  
```json
{
	// This comment will be ignored by the application
	"My Category":
	{
		"Path1": [ "path/to/folder1", "path/to/folder2" ]
	}
}
```
`"My Category"` is the category name. It will be shown at the start of the app.
`"Path1"` is the name of the path inside of the category.  
- Any comments or trailing commas **will be ignored by the application**
  - i am still unsure if ignoring trailing commas is a good idea.
<img width="595" height="183" alt="image" src="https://github.com/user-attachments/assets/9df904f5-7014-49f5-b8e4-c059d72d577d" />
  
**Note:** Json doesnt suppoort the single `\`, so its advised to use the `\\` or `/` instead.
But i actually want to fix this *"issue"*  
It also supports comments on the file. So dont be afraid if the syntax of your editor says its a error!

# The App itself
At selecting in one of the categories, a set of paths will be shown.  
So selecting a path, *it will open all the paths inside of it. At same time*  
- Please note that if the path is invalid, it will open the `Documents` folder as default
  - I still want to fix this yet.
# TODO *(Please ignore, except you, Slugg!)*
- Changing the default `"Docuuments"` folder to set a error if given path is invalid
- Making it support single `\`
- ~~Making JSON support Comments (comments are nice ;] )~~
