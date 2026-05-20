# FolderOpenerGUI
My version of FolderOpener, but now its made with WPF! (unsurprising)

# JSON Format
The `Path.json` is the file responsable for showing the category and the path  
```json
{
	"My Category":
	{
		"Path1": [ "path/to/folder1", "path/to/folder2" ]
	}
}
```
`"My Category"` is the category name. It will be shown at the start of the app.
`"Path1"` is the name of the path inside of the category.  
<img width="580" height="158" alt="image" src="https://github.com/user-attachments/assets/b5a72e7e-e807-4bce-9cc0-ceb429d559bb" />  
**Note:** Json doesnt suppoort the single `\`, so its advised to use the `\\` or `/` instead.
But i actually want to fix this *"issue"*  
It also supports comments on the file. So dont be afraid if the syntax of your editor says its a error!

# The App itself
At selecting in one of the categories, a set of paths will be shown.  
So selecting a path, *it will open all the paths inside of it. At same time*  
- Please note that if the path is invalid, it will open the `Documents` folder as default
  - I still want to fix this yet.
<img width="403/2" height="458/2" alt="image" src="https://github.com/user-attachments/assets/22416c14-696f-4776-a029-3e8820bb7ccc" />
 
# TODO *(Please ignore, except you, Slugg!)*
- Changing the default `"Docuuments"` folder to set a error if given path is invalid
- Making it support single `\`
- ~~Making JSON support Comments (comments are nice ;] )~~
