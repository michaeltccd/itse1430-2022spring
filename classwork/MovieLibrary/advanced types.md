# Advanced Types

## Interfaces

An interface is a contract between an implementation and users.

The interface defines the member(s) that a type will implement and other code can use.
Interfaces represent some functionality that a type may implement.

```
interface ISomeFeature
{
    T SomeProperty { get; set; }

    T SomeMethod ( {parameters} );

    event T SomeEvent;
}
```

- Interface names always start with an "I" and then a Pascal-cased action name.
- Interface members are limited to properties, methods and events.
- Interface members are always public (because it represents a contract).
- Properties can have getter, setter or both.
- No implementation is provided.
- An interface type cannot be directly created because it is just a contract.
- An interface is considered immutable once it is publicly released.

### Common Interfaces

`IComparable<T>`::
   Supports comparing two objects for relationships (less than, greater than, etc).
`IEnumerable<T>`::
   Supports forward, readonly enumeration of a set of items. How the enumeration works is undefined.
`IEqualityComparer<T>`::
   Supports testing for equality of two objects. Not supported in all situations.
`IValidatableObject`::
   Supports validating an instance of an object.

### Using Interfaces

Interfaces are regular types and can be used anywhere a type is allowed except in a `new` expression.

```
//Compiler error, cannot create an instance of an interface
ISomeFeature feature = new ISomeFeature(); 

//Can assign a type that implements the interface to an interface variable
ISomeFeature feature = new SomeFeature();
```

Interfaces do not change the runtime instance in any way. An interface simply limits what the code can see.

### Implementing an Interface

A type implements an interface by placing the interface name after the type declaration like a base type.

```
class SomeFeature : ISomeFeature
{
}
```

- A type that implements an interface must provide public members for all the interface members.
- A type may implement any number of interfaces.
- A value or reference type may implement interfaces.
- A type is responsible for implementing all the interface members.

## Abstract Class

A class that has one or more abstract members.

The class cannot be directly instantiated because it is missing members. It must be derived from.

```
abstract class Shape
{
   public abstract void SomeMethod ();
}
```
Abstract classes are generally used to help implement an interface.

```
abstract class SomeFeature : ISomeFeature
{
    public abstract void MustOverride ();

    public virtual void MayOverride () { }
}
```

- All abstract members must be implemented in a derived type.

## Static Class

A class that cannot be instantiated.

Most useful for grouping related functionality together when a class instance is not needed.

```
static class SomeClass
{
}
```

- A static class cannot be instantiated using new.
- Static classes cannot have a base type or implement interfaces.
- There are no instances of the class.
- All class members must be static.
- No `this` pointer is passed to methods.
- Class members cannot be protected, virtual or abstract.

## Extension Methods

Extension methods extend an existing type with new methods.

Extension methods look like instance methods on the extended type but are actually just static methods on static classes.
This makes extension methods more discoverable than normal static methods.

```
public static class StringExtensions
{
    public static string PrettyPrint ( this string source )
    { ... }
}

string str = "Some Value";
str = str.PrettyPrint();

//Equivalent to and interchangeable with
str = StringExtensions.PrettyPrint(str);
```

- Can be used on any type including types that the code does not own.
- Only methods are supported.
- Methods public be on a public or internal static class.
- Methods must have a first parameter of the extended type and be preceded by the keyword `this`.
- Extension methods do not have any extra visibility into an extended type.

## LINQ

Language Integrated Natural Query is a library for being able to query and work with `IEnumerable<T>` using a database-like syntax.

All the functionality is implemented using extension methods, mostly defined on `Enumerable`.

Some commonly used methods include:

`Any`::
   Returns true if there are any items in the set.
`Count`::
   Gets the number of items in the set.
`FirstOrDefault`::
   Gets the first item from the set, if any, or the default value for the type otherwise.
`LastOrDefault`::
   Gets the last item from the set, if any, or the default value for the type otherwise. NOTE: Does not work in all cases.
`OrderBy`::
   Orders a set of items using the given expression (`Func<T, ?>`), generally a property. Subsequent ordering uses `ThenBy`.
`SingleOrDefault`::
   Gets the only item from the set, if any, or the default value for the type otherwise (if there is less or more than 1).
`Select`::
   Transforms an `IEnumerable<T>` to an `IEnumerable<R>` using a transform method passed as an argument (`Func<T, R>`).
`ToArray`::
   Converts `IEnumerable<T>` to `T[]`.
`ToList`::
   Converts `IEnumerable<T>` to `List<T>`.
`Where`::
   Returns `IEnumerable<T>` containing items that match the predicate (`Func<T, bool>`) passed to the method.

## Lambdas (Anonymous Methods)

A lambda is an expression that the compiler converts to an anonymous method.

It is a lot like a temporary variable that the compiler generates.

```
//Full method
int GetValue ( string value )
{
    return Int32.Parse(value);
}

//Lambda equivalent
value => Int32.Parse(value)
```

Most useful when the expression is so simple that full method syntax is overkill.
Can be used anywhere a method object is required.

Lambda signatures are normally inferred by compiler based upon context.

```
(T param1 {, T parm2}*) => E
() => E
param1 => E
```

- Parenthensis are required except when there is a single parameter.
- Type can be excluded if compiler can infer
- A single expression can be used and acts as return type of expression.
- Multiple statements can be wrapped in block statement but must include a return statement explicitly.

### Captures

Can capture the values of local variables and parameters of the method it is declared in.

```
IEnumerable<Student> FindStudents ( int grade )
{
    return _students.Where(x => x.Grade >= grade);
}
```

- Captured values cannot be modified.
- Out and ref parameters cannot be captured.
   
## LINQ Syntax

An optional, natural query syntax for queries that use standard database logic (select, from, where, orderby).

```
from x in items
where x.Id > 0
orderby x.Name, x.Duration
select x;
```

The syntax is equivalent to using the corresponding LINQ extension methods but in a more natural syntax.

```
items.Where(x => x.Id > 0)
     .OrderBy(x => x.Name)
     .ThenBy(x => x.Duration);     
```

Extension methods may be called on the expression if necessary but be sure to wrap the entire expression in parenthesis.

```
(from x in items
 where x.Id > 0).FirstOrDefault();
```

## Expression Bodies

In the special case of a method, constructor or property getter/setter that is a single line then a lambda expression may be used instead.

```
class SomeClass
{
    /*int GetValue ()
    {
        return 10;
    }*/
    int GetValue () => 10;

    /*string Name {
       get { return _name ?? ""; }
       set { _name = value?.Trim(); }
    }*/
    string Name {
        get => _name ?? "";
        set => _name = value?.Trim();
    }

    /*double Area {
       get { return 10 * 20; }
    }*/
    double Area => 10 * 20;
}
```

The compiler rewrites the expression body to a regular method/property.