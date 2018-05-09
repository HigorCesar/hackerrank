module Tests
open Xunit

[<Theory>]
[<InlineData(1,6)>]
[<InlineData(2,10)>]
[<InlineData(3,14)>]
let ``Calculate when size equals x`` size expectedArea =
    let cube = Array2D.create 1 1 size
    let actual = Calculator.Calculate cube 0 0
    Assert.Equal(expectedArea,actual)

[<Fact>]
let ``Calculate when size equals one but there is one neighbor on the left``() = 
     let cube = Array2D.create 1 2 1
     let actual = Calculator.Calculate cube 0 1
     Assert.Equal(5,actual)

[<Fact>]
let ``Calculate when size equals one and there is one neighbor on the right``() = 
     let cube = Array2D.create 1 2 1
     let actual = Calculator.Calculate cube 0 0
     Assert.Equal(5,actual)

[<Fact>]
let ``Calculate when size equals one and there is one neighbor on the left``() = 
     let cube = Array2D.create 1 2 1
     let actual = Calculator.Calculate cube 0 1
     Assert.Equal(5,actual)

[<Fact>]
let ``Calculate when size equals one and there is one neighbor one line before``() = 
     let cube = Array2D.create 2 1 1
     let actual = Calculator.Calculate cube 1 0
     Assert.Equal(5,actual)
    
[<Fact>]
let ``Calculate when size equals one and there is one neighbor one line after``() = 
     let cube = Array2D.create 2 1 1
     let actual = Calculator.Calculate cube 0 0
     Assert.Equal(5,actual)

[<Fact>]
let ``Calculate when size equals two and neighbor is equals two``() = 
     let cube = Array2D.create 1 2 2
     let actual = Calculator.Calculate cube 0 0
     Assert.Equal(8,actual)

[<Fact>]
let ``Calculate ignore neighbor size when it is bigger than current cube``() = 
     let cube = Array2D.create 1 2 1
     cube.[0,0] <- 2
     let actual = Calculator.Calculate cube 0 1
     Assert.Equal(5,actual)

[<Fact>]
let ``CalculateWholeCube w``() = 
     let cube = Array2D.create 3 3 0
     cube.[0,0] <- 1
     cube.[1,0] <- 3
     cube.[2,0] <- 4

     cube.[0,1] <- 2
     cube.[1,1] <- 2
     cube.[2,1] <- 3

     cube.[0,2] <- 1
     cube.[1,2] <- 2
     cube.[2,2] <- 4     
     let actual = Calculator.CalculateWholeCube cube
     Assert.Equal(60,actual)