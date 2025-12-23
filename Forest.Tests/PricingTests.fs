module Tests

open System
open Xunit
open Forest
open Forest.Types

[<Fact>]
let ``BlackScholes_EuropeanCall`` () =
    //arrange
    let market =
        {
            Values = [ ("ABC", 101.0) ] |> Map.ofList
            ImpliedVols = [ ("ABC", 0.2) ] |> Map.ofList
            RiskFreeRate = 0.05
            ValuationDate = DateTime(2025, 12, 16)
        }
    let option = EuropeanCall(100., DateTime(2025, 12, 23), "ABC")

    //act
    let value = Pricing.BlackScholes market option
                |> fun v -> Math.Round(v, 2)

    //assert
    let expected = 1.74
    Assert.Equal(expected, value)