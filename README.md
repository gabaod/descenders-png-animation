Welcome to how to implement png animations from blender into unity 2017 to be exported into the game Descenders

First off you will need to import the StreamingFlagAnimator.cs into your assets/scripts/ folder in unity
And secondly visit this youtube link and Ill show a quick demonstration of the full process.<br><br><br><br>

In Blender:<br><br>
You first need your object to have a cloth texture<br>
Than you need to make a vertex group - go into edit mode select the vertices you want to not be effected by wind and assign them to a new vertex group<br>
Under physics under Shape pin your vertex group you just made<br>
Create a new object of wind or vortex to set up to how you like the animation<br>
Now we need to make keyframes within your animation ie setting strength of wind to 0 on frame 1, set it to strength 10 on frame 5 set it to strength 20 on frame 15 make another keyframe at frame 80 with strength 20, frame 90 set it to strength 10 and back to 0 on frame 100 etc as a basic example<br>
You will need to rebake your object anytime you change a cloth setting or wind direction or setting<br>
When ready to import to unity, goto render settings make Film - transparent checked<br>
Under output set the resolution to be equal ie 1024 x 1024<br>
Set your frame rate and range<br>
Set your output directory path<br>
Make sure its set to PNG, RGBA, 8<br>
Now create a camera so using numpad 0 shows just the animation in the window, hit the camera icon to remove any other object from being rendered within that camera view<br>
It is very important your camera only shows your item you wish to animate and it doesnt go outside the camera window<br>
Now goto render and render animation and all your pngs should be in your set directory path to now import into unity 2017<br><br><br><br>



In Unity:<br><br>
Import your fbx<br>
Import all your png files from blender<br>
Create a new material<br>
  Set the Shader to Unlit/Transparent<br>
  Select your object in unity that should be animated<br>
  Make sure it has a mesh renderer and mesh filter<br>
    In mesh renderer drag your new material where it says Element 0<br>
  Goto Add component and search for StreamingFlagAnimator<br>
    Set the size to how many frames your animation is - ie how many png files do you have<br>
    Make sure each png is named in a proper format 0001.png for up to 999 frames or 00001.png for up to 9999 frames<br>
    Drag each png in sequential order into each Element start at Element 0<br>
    If you have problems here make sure when you did render animation in blender they had the proper settings of output resolution being equal dimensions ie 1024x1024<br>
      file format is png,<br> color is rgba,<br> color depth is 8 (16 will not work)<br>
    And than hit play in unity or export to descenders to view how your animation works<br>

    
Here is a basic example of animating pennant flags in descenders   https://youtu.be/5Gs0KhCt2uA
