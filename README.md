Welcome to how to implement png animations from blender into unity 2017 to be exported into the game Descenders

First off you will need to import the StreamingFlagAnimator.cs into your assets/scripts/ folder in unity
And secondly visit this youtube link and Ill show a quick demonstration of the full process.




In Unity:
Import your fbx
Import all your png files from blender
Create a new material
  Set the Shader to Unlit/Transparent
  Select your object in unity that should be animated
  Make sure it has a mesh renderer and mesh filter
    In mesh renderer drag your new matieral where it says Element 0
  Goto Add component and search for StreamingFlagAnimator
    Set the size to how many frames your animation is - ie how many png files do you have
    Make sure each png is named in a proper format 0001.png for up to 999 frames or 00001.png for up to 9999 frames
    Drag each png in sequential order into each Element start at Element 0
    If you have problems here make sure when you did render animation in blender they had the proper settings of output resolution being equal dimensions ie 1024x1024
      file format is png, color is rgba, color depth is 8 (16 will not work)
    And than hit play in unity or export to descenders to view how your animation works

    
Here is a basic example of animating pennant flags in descenders   https://youtu.be/5Gs0KhCt2uA
