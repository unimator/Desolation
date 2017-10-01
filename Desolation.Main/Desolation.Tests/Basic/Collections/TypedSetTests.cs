using System;
using System.Linq;
using Desolation.Basic.Collections;
using NUnit.Framework;

namespace Desolation.Tests.Basic.Collections
{
    [TestFixture]
    public class TypedSetTests
    {
        private class FooBase { }

        private class Foo1 : FooBase { }
        private class Foo2 : FooBase { }
        private class Foo3 : Foo1 { }
        
        [TestCase]
        public void ShouldThrowExceptionWhenTryingToInsertItemOfExistingType()
        {
            var set = new TypedSet<FooBase>();

            set.Insert(new Foo1());
            set.Insert(new Foo2());
            Assert.Throws(typeof(Exception), () =>
            {
                set.Insert(new Foo1());
            }, $"Collection already contains an item of type {new Foo1().GetType()}");
        }

        [TestCase]
        public void ShouldAllowToInsertItemsOfDifferentType()
        {
            //arrange
            var set = new TypedSet<FooBase>();

            //act
            set.Insert(new Foo1());
            set.Insert(new Foo2());
            set.Insert(new Foo3());

            //assert
            Assert.AreEqual(3, set.Count());
        }

        [TestCase]
        public void ShouldReturnTrueIfContainsItemOfDesiredType()
        {
            //arrange
            var set = new TypedSet<FooBase>();
            
            set.Insert(new Foo1());
            set.Insert(new Foo2());

            //act
            var result = set.Contains<Foo1>();

            //assert
            Assert.IsTrue(result);
        }

        [TestCase]
        public void ShouldTellFalseIfContainsItemOfDesiredType()
        {
            //arrange
            var set = new TypedSet<FooBase>();

            set.Insert(new Foo1());
            set.Insert(new Foo2());

            //act
            var result = set.Contains<Foo3>();

            //assert
            Assert.IsFalse(result);
        }

        [TestCase]
        public void ShouldReturnItemOfDesiredTypeIfContains()
        {
            //arrange
            var set = new TypedSet<FooBase>();
            var desiredItem = new Foo3();

            set.Insert(new Foo1());
            set.Insert(new Foo2());
            set.Insert(desiredItem);

            //act
            var returnedItem = set.Get<Foo3>();

            //assert
            Assert.AreEqual(desiredItem, returnedItem);
        }

        [TestCase]
        public void ShouldReturnNullIfDoesNotContain()
        {
            //arrange
            var set = new TypedSet<FooBase>();

            set.Insert(new Foo1());
            set.Insert(new Foo2());

            //act
            var returnedItem = set.Get<Foo3>();

            //assert
            Assert.AreEqual(null, returnedItem);
        }

        [TestCase]
        public void ShouldReturnNullIfEmpty()
        {
            //arrange
            var set = new TypedSet<FooBase>();
            
            //act
            var returnedItem = set.Get<Foo1>();

            //assert
            Assert.AreEqual(null, returnedItem);
        }

        [TestCase]
        public void ShouldRemoveItemOfDesiredTypeIfExistsInSet()
        {
            //arrange
            var set = new TypedSet<FooBase>();
            var itemToRemove = new Foo2();

            set.Insert(new Foo1());
            set.Insert(itemToRemove);

            //act
            set.Remove(itemToRemove);
            var containsResult = set.Contains<Foo2>();

            //assert
            Assert.AreEqual(false, containsResult);
            Assert.AreEqual(1, set.Count());
        }

        [TestCase]
        public void ShouldDoNothingIfItemOfDesiredTypeDoesNotExistInSet()
        {
            //arrange
            var set = new TypedSet<FooBase>();
            var itemToRemove = new Foo3();

            set.Insert(new Foo1());
            set.Insert(new Foo2());

            //act
            set.Remove(itemToRemove);
            var containsResult = set.Contains<Foo2>();

            //assert
            Assert.AreEqual(true, containsResult);
            Assert.AreEqual(2, set.Count());
        }
    }
}