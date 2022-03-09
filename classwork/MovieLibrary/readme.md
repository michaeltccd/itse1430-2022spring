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

```
property-decl ::= full-property-decl | auto-property-decl
full-property-decl ::= [access] [modifiers] T id { [[access] get { S* }] [[access] set { S* }] }
auto-property-decl ::= [access] [modifiers] T id { [[access] get;] [[access] set;] }
```

Can optionally be read only (calculated) or write only (rare) by excluding accessors.

getter has signature `T get_id ()` and must return a value of T.
setter has signature `void set_id (T value)`.

*Note:Properties do not store data.*

### Naming

- Noun
- Pascal cased

### Accessibility

Any but often `public`.

Can use a more restrictive accessibility on either the getter or setter if desired.

//  Use auto property syntax when property is simply reading/writing backing field
//    Do not declare the backing field
//  property-declaration ::= [access] [modifiers] T id { accessors }    
//  accessors ::= full-accessors | auto-accessors
//  full-accessors ::= [[access] get { S* }] [[access] set { S* }]
//  auto-accessors ::= [[access] get;] [[access] set;]

// Handling null
//   null coalescing ::= E ?? E, find first non-null
//   null conditional ::= E?.M, execute M if E not null, changes type to T?
//   combined ::= E?.M ?? D, resets type back to T            
    