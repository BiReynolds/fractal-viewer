# Todo
Need to refactor Imager classes so that we don't need to create the rawData array new each time

# Current Plans
## Image Save functionality
- User will be able to save the current rendering as an image 
## Zoom functionality
User will be able to select a portion of the graph and zoom in on it (there will need to be a limit due to loss of precision at certain levels of zoom)
- User will select the zoom by clicking and dragging a selection Rectangle on the screen.  The program will then zoom to a frame which is as small as possible while still containing the user's entire selected area.  Additionally, the box the user selected should be centered in the frame 
- User should be able to undo a zoom to return to the previous zoom
- User should be made aware when they have reached the limit of rendering due to loss of precision, and prevented from zooming further
## Individual Orbit Viewing
User can select an individual within the rendered image and see the "orbit" of that point under the selected iterator
- Right-clicking on the screen will select a point for orbit viewing
- Orbit should appear as several points connected by arrows, showing the progression of the point as the function is continuously applied
- Orbit should stop on its own after some number of iterations
- For an orbit which is currently active, user can hover over individual points to see the location in the complex plane (and maybe other info)
- User can have multiple orbits on screen at once
- Orbits can be removed by hovering any of the points along the orbit and right-clicking (may eventually make a context menu for orbit handling, but that will be a phase 2 thing)
## Styling Wizard
User can tweak the rendering process to get unique images
- User can select if there is a grid under the fractal image, and the granularity of this grid
- So far there are two rendering "types": binary or gradient
- In both rendering types, user can select a custom "on" color and "off" color
- User can edit the color intensity transform (will write more on this when it is implemented)
## Landing screen and "What is This" wizard
On program open, user will be presented with a landing screen with two options: "Jump Right In" and "What is This?" 
- Clicking "Jump Right In" will take the user straight to the Renderer
- Clicking "What is This?" will show an interactive introduction to the concept of the Mandelbrot set, Julia sets, etc. 
- Lets user play with the orbit viewing functionality **without** any fractals present (using the equation, say, x^2 + 1), suggesting certain points to show a variety of interesting behaviors
- Introduces the idea of convergence, divergence, and periodic behavior
- Introduces the "Filled Julia Set" and renders it
- Introduces the Mandelbrot Set and its relation to these filled Julia Sets
# Future Plans (need to do more research)
## Coloring of Fatou Sets