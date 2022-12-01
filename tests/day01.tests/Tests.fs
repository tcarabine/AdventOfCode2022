module Tests

open System
open Xunit
open FluentAssertions

open Day1

[<Fact>]
let ``Functions.bundle should produce 2 items when given a string with a single \n\n`` () =
  //Arrange
  let input = "line1\nline2\n\nline4"

  //Act
  let result = Functions.bundle input

  //Assert
  result.Should().HaveCount(2, "there is only one \\n\\n provided")

[<Fact>]
let `` Functions.most should return 24000 for the sample input`` () =
  //Arrange 
  let input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000"

  //Act
  let result = Functions.most input

  //Assert
  result.Should().Be(24000, "this is the sample value")
[<Fact>]
let ``Functions.top3 should return 45000 for the sample input``   () =
  //Arrange 
  let input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000"

  //Act
  let result = Functions.top3 input

  //Assert
  result.Should().Be(45000, "this is the sample value")