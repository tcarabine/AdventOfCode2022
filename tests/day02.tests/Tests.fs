module Tests

open System
open Xunit
open FluentAssertions

open Day2

[<Theory>]
[<InlineData('P','P',3)>]
[<InlineData('P','R',0)>]
[<InlineData('P','S',6)>]
[<InlineData('R','P',6)>]
[<InlineData('R','R',3)>]
[<InlineData('R','S',0)>]
[<InlineData('S','P',0)>]
[<InlineData('S','R',6)>]
[<InlineData('S','S',3)>]
let ``Rules work for scoring`` (them, you, expected) =
    //Arrange
    let input = (them,you)

    //Act
    let result = Functions.play(input)

    //Assert
    let outcome = 
      match expected with
      | 0 -> "is beaten by"
      | 3 -> "is"
      | 6 -> "beats"
    
    result.Should().Be(expected, $"becuase {you} {outcome} {them}")


[<Theory>]
[<InlineData("A Y",'R','P')>]
[<InlineData("B X",'P','R')>]
[<InlineData("C Z",'S','S')>]
let ``Parsing is working`` (input, expectedThem, expectedYou) =
    //Arrange
    let expected = (expectedThem, expectedYou)

    //Act
    let result = Functions.parse(input)

    //Assert   
    result.Should().Be(expected, $"becuase {input} should parse to ({expectedThem},{expectedYou})")


[<Theory>]
[<InlineData('P','L','R')>]
[<InlineData('P','W','S')>]
[<InlineData('P','D','P')>]
[<InlineData('R','L','S')>]
[<InlineData('R','W','P')>]
[<InlineData('R','D','R')>]
[<InlineData('S','L','P')>]
[<InlineData('S','W','R')>]
[<InlineData('S','D','S')>]
let ``Geting your move works`` (them, outcome, expected) =
    //Arrange
    let input = (them,outcome)

    //Act
    let result = Functions.getMove(input)

    //Assert
    let outcomeString = 
      match outcome with
      | 'W' -> "beats"
      | 'L' -> "is beaten by"
      | 'D' -> "is"
    
    result.Should().Be(expected, $"becuase {result} {outcomeString} {them}")