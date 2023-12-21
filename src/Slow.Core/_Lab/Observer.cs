// using System;

// // Define the subject (publisher)
// public class Subject
// {
//     // Define the delegate that represents the method signature for the event
//     public delegate void StateChangeHandler(string newState);

//     // Define the event based on the delegate
//     public event StateChangeHandler StateChanged;

//     private string state;

//     public string State
//     {
//         get { return state; }
//         set
//         {
//             if (state != value)
//             {
//                 state = value;

//                 // Notify observers when the state changes
//                 OnStateChanged(state);
//             }
//         }
//     }

//     // Helper method to raise the event
//     protected virtual void OnStateChanged(string newState)
//     {
//         StateChanged?.Invoke(newState);
//     }
// }

// // Define an observer (subscriber)
// public class Observer
// {
//     private string name;

//     public Observer(string name)
//     {
//         this.name = name;
//     }

//     // Event handler method that will be called when the state changes
//     public void HandleStateChanged(string newState)
//     {
//         Console.WriteLine($"{name} received notification. New state: {newState}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Create a subject
//         Subject subject = new Subject();

//         // Create observers
//         Observer observer1 = new Observer("Observer 1");
//         Observer observer2 = new Observer("Observer 2");

//         // Subscribe observers to the subject's event
//         subject.StateChanged += observer1.HandleStateChanged;
//         subject.StateChanged += observer2.HandleStateChanged;

//         // Change the state, and observers will be notified
//         subject.State = "New State 1";
//         subject.State = "New State 2";

//         // Unsubscribe an observer
//         subject.StateChanged -= observer1.HandleStateChanged;

//         // Change the state again, and only observer2 will be notified
//         subject.State = "New State 3";
//     }
// }
