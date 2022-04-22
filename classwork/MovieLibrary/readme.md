# Modifiers 

## Accessibility

Access modifiers control access to a type/member for compilation purposes

- public ::= Everyone.
- protected ::= Declaring and derived types only.
- internal ::= Assembly only (default for top level types).
- private ::= Declaring type only (default for type members).

# Members

- virtual ::= Derived types may override the implementation if desired.
- abstract ::= Derived types must override the implementation.
- override ::= In a derived type, identicates the base type implementation is overridden.

# Class

Wraps data and functionality

```
class-declaration ::= [access] [modifiers] class id { class-member* }
class-member ::= field-decl | method-decl | property-decl | event-decl | ctor-decl
```
## Naming

- nouns
- Pascal cased

# Class Members

The `this` keyword represents the current instance on which a member is called.
It is rarely needed in code but can be used to disambiguate an identifier.

```
int age;
void Foo ( int age )
{
    //Setting the parameter to 10
    age = 10;

    //Setting the field to 10
    this.age = 10;
}
```

## Fields

Stores data.

```
field-decl ::= [access] [modifier] T id [= initializer-expression];
```

Can be read or written like regular local variables.

Can not be virtual.

### Naming

- Noun
- Camel cased, start with underscore

### Accessibility

Private in most cases. Can be public if read only.

## Properties 

Exposes data using a field-like syntax but backed by method(s).

*Note:Properties do not store data.*

```
property-decl ::= full-property-decl | auto-property-decl
full-property-decl ::= [access] [modifiers] T id { [[access] get { S* }] [[access] set { S* }] }
auto-property-decl ::= [access] [modifiers] T id { [[access] get;] [[access] set;] }
```

The getter returns a value whenever the property is read. It has the signature `T get_id ()` and must return a value of T.

The setter is called when the property is written to. It has the signature `void set_id (T value)`.

### Calculated Properties

A property may optionally be read only (calculated) or write only (rare) by excluding an accessor.
This is most useful when returning a value that is calculated based upon other values.

```
//Read only property
public int AgeInYears
{
    get { return DateTime.Today - DateOfBirth; }
}

//Write only property
public string Password
{
    set { _password = value; }
}
```

### Auto Properties

When a property simply gets or sets a backing field then the auto-property syntax can be used instead.

```
public int Age { get; set;}

//Equivalent to
public int Age 
{
    get { return _age; }
    set { _age = value;}
}
private int _age;
```

Mixed accessibility and optional getter/setters are still allowed.

*Note: Do not declare the backing field.*

### Naming

- Noun
- Pascal cased

### Accessibility

Any but often `public`.

Can use a more restrictive accessibility on either the getter or setter if desired.

## Methods

Functions defined in a class.

All the standard "function" rules already discussed apply to methods.

# Null Handling

Attempting to do most anything with a `null` instance will cause a runtime error.
Code should deal with `null` on reference types.

null-coalesce ::= E ?? E
null-conditional ::= E?.Member

## Null Coalescing

Selects the first non-`null` expression.

```
public string Name
{
   // Returns the name, if not null, or an empty string otherwise
   get { return _name ?? ""; }
}
```

## Null Conditional

Calls a member of a class if the instance is not `null`.

```
//Trims the string if it is not null
var trimmedValue = value?.Trim();
```

The call is skipped if the instance is `null` and therefore it changes the type of the resulting expression
to be either the original type T or `null`. Hence value types become nullable.

```
public class Person
{
    public int Age { get; set; }
}

void PrintAge ( Person person )
{
    //Type remains the same but will crash if instance is null
    int age = person.Age;

    //Type is now nullable int but will not crash if instance is null
    int? nullableAge = person?.Age;
}
```
    
To work around the type change it is common to combine the null conditional operator with the null coalescing.

```
int age = person?.Age ?? 0;
```
- [Classes]()
- [Advanced Types](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/readme.adoc)
  - [Interfaces](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-6/interfaces.adoc)
    - [Using Interfaces](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-6/interfaces.adoc#working-with-interfaces)
    - [Common Interfaces](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-6/interfaces.adoc#common-interfaces)
    - [Implementing Interfaces](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-6/interfaces.adoc#implementing-interfaces)
  - [Abstract Class](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/abstract-classes.adoc)
  - [Static Class](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/static-classes.adoc)
    - [Extension Methods](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/extension-methods.adoc)
  - [LINQ](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/linq.adoc)
    - [Common `IEnumerable<T>` Methods](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/linq-extension-methods.adoc)
    - [Lambdas](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/lambda-expressions.adoc)
    - [LINQ Syntax](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/linq-syntax.adoc)
    - [Expression Bodies](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-7/expression-body.adoc)

# Unit 7

- [Exceptions](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/exceptions.adoc#exception-class)
  - [Common Exceptions](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/exceptions.adoc#common-exceptions)
  - [System Exceptions](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/exceptions.adoc#system-exceptions)
- [Raising Exceptions](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/throwing-exceptions.adoc)
  - [Throw Statement](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/throwing-exceptions.adoc#throw-statement)
- [Handling Exceptions](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/handling-exceptions.adoc)
  - [Try-Catch Statement](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/try-catch.adoc)
  - [Try-Finally Statement](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-8/try-finally.adoc)

# Unit 8

- [Files](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-9/files.adoc)
  - [Streamed IO](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-9/stream-io.adoc)
- [Resource Management](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-9/resource-management.adoc)
  - [IDisposable Interface](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-9/interface-idisposable.adoc)
  - [Using Statement](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-9/using-statement.adoc)
  
# Unit 9

- [ADO.NET](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/ado-net.adoc)
  - [DbConnection](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/connections.adoc)
  - [DbCommand](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/commands.adoc)
    - [Executing Commands](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/commands.adoc#executing-commands)
  - [Reading Data](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/reading-data.adoc)
    - [Dataset](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/datasets.adoc)
    - [Datareader](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-10/datareader.adoc)

