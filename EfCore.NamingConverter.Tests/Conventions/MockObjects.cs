using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.NamingConverter.Tests.Conventions
{
    public class SampleEntity
    {
        public int SampleEntityId { get; set; }

        public int SomeProperty { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }

        public required List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public required Blog Blog { get; set; }

        public int BlogId { get; set; }

        public required string PostTitle { get; set; }
    }

    public class Parent
    {
        public int Id { get; set; }
        public int ParentProperty { get; set; }
    }

    public class Child1 : Parent
    {
        public int ChildOneProperty { get; set; }
    }

    public class Child2 : Parent
    {
        public int ChildTwoProperty { get; set; }
    }

    public abstract class AbstractParent
    {
        public int Id { get; set; }

        public int ParentProperty { get; set; }
    }

    public class ChildOfAbstract : AbstractParent
    {
        public int ChildProperty { get; set; }
    }

    public class ChildWithOwned : Parent
    {
        public int ChildProperty { get; set; }

        public required Owned Owned { get; set; }
    }

    public class Split1
    {
        public int Id { get; set; }

        public int OneProp { get; set; }

        public int Common { get; set; }

        public required Split2 S2 { get; set; }
    }

    public class Split2
    {
        public int Id { get; set; }

        public int TwoProp { get; set; }

        public int Common { get; set; }

        public required Split1 S1 { get; set; }
    }

    public class Owner
    {
        public int Id { get; set; }

        public int OwnerProperty { get; set; }

        public required Owned Owned { get; set; }

        [NotMapped]
        public required Owned Owned2 { get; set; }
    }

    public class Owned
    {
        public int OwnedProperty { get; set; }

        [NotMapped]
        public required List<NestedOwned> NestedOwnedCollection { get; set; }
    }

    public class NestedOwned
    {
        public int Foo { get; set; }
    }

    public class Waypoint
    {
        public int Id { get; set; }

        public required Location Location { get; set; }
    }

    public class Location
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }

    public class ReferenceNavigationPrincipal
    {
        public int Id { get; set; }

        public required ReferenceNavigationDependent Dependent { get; set; }
    }

    public class ReferenceNavigationDependent
    {
        public int Id { get; set; }

        public int PrincipalId { get; set; }

        public required ReferenceNavigationPrincipal Principal { get; set; }
    }

    public class Board
    {
        public int Id { get; }

        public required List<Card> Cards { get; set; }
    }

    public class Card
    {
        public int Id { get; }
        public required Board Board { get; set; }
    }
}
