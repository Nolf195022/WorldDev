# SOLID Principles
## A description (with justifications) of at least two SOLID principles used in the project.
#### S -> Single Responsibility Principle
> A class or method should have one and only one reason to change, meaning that a class should only have one job.

Every method in this project has a single responsability. Each class or method has an appropriate name. They all do one thing, what they were created to do.

*For exemple : The Animal.Move() method has as only responsability to move an Animal. The way in which he will move is defined by a movement manager*

#### L -> Liskov substitution principle
> Let q(x) be a property provable about objects of x of type T.
Then q(y) should be provable for objects y of type S where S is a subtype of T.

All objects initialized in the world (apart from the world itself) have "entity" as a super class. All these objects can use all the methods of the "Entity" class. They can also apply all the other methods of their other parent classes. All the inherited methods can thus be applied to an object affected by this inheritance.

*For exemple : Entity.GetName() is a property provable about objects of type Entity, Lion.GetName() is also provable since Lion is a subtype of Entity.*

#### D -> Dependency Inversion principle
> Entities must depend on abstractions not on concretions.
It states that the high level module
must not depend on the low level module,
but they should depend on abstractions.

Every method that overrides another method don't influence the overrided method.

*For exemple : The GetName() method has been redefined several times. No redefinition affects the operation of the initial method initialized in the Entity class. Any object which inherited from this method can call this method as "entity".*
