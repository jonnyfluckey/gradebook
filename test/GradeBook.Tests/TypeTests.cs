using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]

        public void StringsBehaveLikeValueTypes()
        {
            string name = "Jonny";
            var upper = MakeUppercase(name);

            Assert.Equal("JONNY", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }
        private int GetInt()
        {
            return 3;
        }
        [Fact]
        public void CSharpIsPassByRef()
        {
           
           // arrange
            var book1 = GetBook("Book 1");
            // act
            
            GetBooksSetName(ref book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);


        }
        private void GetBooksSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
           
           // arrange
            var book1 = GetBook("Book 1");
            // act
            
            GetBookSetName(book1, "New Name");

            // assert
            Assert.Equal("Book 1", book1.Name);


        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }
        [Fact]
        public void CanSetNameFromReference()
        {
           
           // arrange
            var book1 = GetBook("Book 1");
            // act
            
            SetName(book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);


        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
           
           // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // act
            

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);


        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
           
           // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // act
            

            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));


        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
        
        
    }
}
