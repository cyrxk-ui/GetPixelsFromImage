# Get Pixels From Image

Download the already built custom activity in the [UiPath Connect Marketplace](https://connect.uipath.com/marketplace/components/get-pixels-from-image/media). This is source code.

Useful when button or background color changes with status.
User can use this activity to check if a certain RGB value is on screen.

**Ex.** If a UI element in a Citrix environment is color coded (a button that changes color when a file is ready for download, red/black text designating credits/debits, etc.), this activity can be used to iterate through on screen pixels and detect that color by passing a screenshot of the current display as input.

## Input
Exactly one of:
* .NET System.Drawing.Image object
* Filepath to existing image file as String

## Output
Array of [Color](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color) objects. Each Color in the array corresponds to the color of a pixel from the input image.