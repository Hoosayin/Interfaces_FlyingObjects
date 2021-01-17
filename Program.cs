using System;
using System.Collections.Generic;

namespace Interfaces_FlyingObjects
{
    // Interfaces are just like Abstract Classes, with the exception that they only have abstract methods.
    // You cannot instantiate Inferface Objects, but the class objects that implement that Interface. Remember, you cannot instantiate Abstract Class objects as well?
    // Classes that implement an interface must implement all the methods of that inferface.
    // Used to add behaviors to different types of classes.
    public interface IFlyable
    {
        void Fly();
    }

    // No human can fly, so Human class will not implement IFlyable interface.
    public class Human
    {
        public string Name;
    }

    // Same is the case with Student. Every Student is a Human, and cannot fly.
    public class Student : Human
    {
        public string Discipline;
    }

    // Here is an exception. FlyingHuman is a Human but can extraordinarily fly.
    // Every Flying Human can fly at a specific altitude.
    public class FlyingHuman : Human, IFlyable
    {
        public double Altitude = 10.0;
        
        public void Fly()
        {
            Console.WriteLine($"Woo-Hoo! I am {Name}, a Flying Human, and I am flying {Altitude} feet above the Earth.");
        }
    }

    // Mallard Duck can also fly.
    // But it flies differently than Flying Human.
    // Its Flying Behavior is determined accroding to the Span of its Wings.
    public class MallardDuck : IFlyable
    {
        public int WingSpan = 81; 

        public void Fly()
        {
            Console.WriteLine($"I am Mallard duck, and I am flying high because my wing-span is {WingSpan} cm.");
        }
    }


    // Here comes a Toy Airplane. Usually, toys cannot fly.
    // But ToyAirPlane has a powerful battery, and a contemporary mechanism that allows it to fly.
    public class ToyAirplane : IFlyable
    {
        public int BatteryCapacity = 5300;
        
        public void Fly()
        {
            Console.WriteLine($"Being a toy, my {BatteryCapacity} mAh Battery will allow me to keep flying up to an Hour. Enjoy Kid!");
        }
    }

    // So far, we have seen that many classes have a Flying Behavior, so they implement IFlyable interface, regardless of their type.
    // We have also noticed that their Flying Behavior is not the same. It varies class to class.
    // So each class has its own implementation of Fly() Method.
    // On the brighter side, we know that Each class has Fly(), and it can fly. :D
    // They can be base or derived classes.
    // They do not require to be in the same hierarchy of classes. It means, if a class wants a Flying Behavior, If does not require to be a Duck or An aircraft.
    // Just implement the IFlyable interface, and Voila!, your class is up for flying. 
    // To-Do: Go Ahead, create a Pizza class, implement IFlyable; You will see your Pizza Flying in the Kitchen within no time. :D

    // Time for some Testing!
    // Below is our driver program!
    // We'll see how we can use the perks of Interfaces in our code. 
    // Let's Dive-In! 
    class Program
    {
        // Our Entry Point.
        static void Main(string[] args)
        {
            // ordinayHuman is Hmuman and cannot Fly.
            Human ordinaryHuman = new Human 
            { 
                Name = "Ahmed Ali" 
            };

            // aCommanStudent cannot fly as well. You know the reason, right? :D
            Student aCommonStudent = new Student
            {
                Name = "Hassan Khan",
                Discipline = "Computer Science"
            };

            // Here, flyingHuman, Mr. Hussain Naeem, can fly; we have already seen why! :)
            FlyingHuman flyingHuman = new FlyingHuman
            {
                Name = "Hussain Naeem",
                Altitude = 20.0
            };

            // Here is a twist!
            // As already said, you cannot instantiate interface objects, but you can declase reference variables to them.
            // Here, we are polymorphically instantiating a MallardDuck object.
            // MallardDuck implements IFlyable, so IFlyable reference variable can be use to dereference a MallardDuck object.
            IFlyable mallardDuck = new MallardDuck();

            // Instantiating a Toy Airplane. 
            ToyAirplane toyAirplane = new ToyAirplane();


            // Here is the best part.
            // In programming practices, we create collections, such as Arrays, Lists, Dictionaries, Tuples, of similar objects. For example, a list of a single class.
            // With Interfaces, we can create collections of objects of different classes provided that they implement a unique Inferface.
            // This is an edge! If we want to move objects of different classes along the code (returning objects of different classes from a Function, for example) we can do that by implementing an interface.
            // Here we have created a list of our Flying Objects.
            List<IFlyable> flyingObjects = new List<IFlyable>();


            // Since, FlyingHuman, MallardDuck, and ToyAirplane, all implement IFlyable.
            // We can add them to or flyingObjects list without any problem.
            flyingObjects.Add(flyingHuman);
            flyingObjects.Add(mallardDuck);
            flyingObjects.Add(toyAirplane);

            // You can iterate over the list, and see how our different flying objects fly over the horizons.
            foreach (var flyingObject in flyingObjects)
            {
                flyingObject.Fly();
            }

            // Did you notice, we instantiated mallardDuck and stored the reference in an IFlyable variable.
            // In the following condition, we are checikng whether mallardDuck is an object of MallardDuck class.
            if (mallardDuck is MallardDuck)
            {
                // If it is, then Down Cast it to Mallard Duck.
                // Down Casting will convert mallardDuck from IFlyable to MallardDuck, and it will store the reference in newMallardDuck variable.
                // And we will be able to use Fields, Properties, and Methods of the MallardDuck class.
                MallardDuck newMallardDuck = mallardDuck as MallardDuck;

                // Here, we are printing Mallard Duck's Wing Span on the console.
                Console.WriteLine($"Wing-span of Mallard Duck = {newMallardDuck.WingSpan}");
            }

            Console.ReadKey();
        }
    }

    /* Consclusion:
     * Here is what we have learned, so far:
     *  1. In interface we define purely abstract methods.
     *  2. Any class can implement an interface, to add new behavior.
     *  3. A class implementing an interface must provide a concrete implementation of each method of that interface.
     *  4. Each class can provide a different and unique implementation of Inteface Methods.
     *  5. We can use polymorphism in interfaces.
     *  6. We can create a collection of objects of different classes, provided that they implement common Interface.
     *  7. We can Upcast of Downcast objects of classes implementing interfaces.
     *  
     *  Future Recommendations:
     *  1. Inheritance of Interfaces.
     *  2. Programming to an Interface.
     *  3. Use of Interfaces in Design Pattens to add Runtime (Dynamic) Behavior in objects.
     *  
     *  I hope, this was useful. Thanks.
     *  
     *  Regards,
     *  Hussain Naeem */
}
