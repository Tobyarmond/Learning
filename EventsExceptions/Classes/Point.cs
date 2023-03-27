using System;

namespace EventsExceptions.Classes
{
    public class Point
    {
        private double _x;
        private double _y;
        
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPointChanged(); // These method calls will call the method which will raise an events if it's not null
            }
        }
        
        public double Y
        {
            get => _y;
            set
            {
                _y = value; 
                OnPointChanged(); // These method calls will call the method which will raise an events if it's not null
            }
        }
        // This is how an Event is declared. The event keyword makes this an event that others can attach to.
        // EventHandler in this case is the delegate type to be used with this event. But any other delegate can be used
        // EventHandler is a built in delegate for handling simple events which has a void return type and two paramaters
        // both of which are objects, one is the sender of the event (this) and the other is EventArgs which is some information
        // about the event itself. 
        
        public static event EventHandler PointChanged;
        
        // Before raising an event you should consider the following code:
        // if (PointChanged != null){PointChanged(this, EventArgs.empty);}
        // CHECK THAT THE EVENT IS NOT NULL!
        // if the event is null it means that they are no eventhandlers attached to the event and calling the event will
        // cause a null reference exception.
        
        // Whilst the code for raising an event can go anywhere it's probably best to put it in its own method with On
        // before the event name. for example

        public void OnPointChanged()
        {
            // I added this to see if it was possible, book example still insists on being static
            PointChanged += HandlePointChanged;
            if (PointChanged != null)
            {
                PointChanged(this,EventArgs.Empty);
            }
        }
        // Now that we have setup all of our event stuff we need to now attach a method to the delegate being called with
        // each event, in this case EventHandler which requires two object params and has no return. Like the raising the
        // event code this can go anywhere.

        public static void HandlePointChanged(object sender, EventArgs eventArgs)
        {
            // Do something good when the point has changed like redraw the GUI or something 
        }
        // The example for this is actually a bit crappy as it does not work properly 
    }
}