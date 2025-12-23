module MarketTests

open System
open Xunit
open Forest
open Forest.Types

[<Fact>]
let ``GetOptionMarketValues`` () =
    //arrange
    let market =
        {
            Values = [ ("ABC", 101.0) ] |> Map.ofList
            ImpliedVols = [ ("ABC", 0.2) ] |> Map.ofList
            RiskFreeRate = 0.05
            ValuationDate = DateTime(2025, 12, 16)
        }
    let option = EuropeanCall(100., DateTime(2025, 12, 18), "ABC")

    //act
    let values = Market.GetOptionMarketValues market option

    //assert
    let expected = { Spot = 101.; ImpliedVol = 0.2 }
    Assert.Equal(expected, values)