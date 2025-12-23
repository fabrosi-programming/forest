open System
open Forest
open Forest.Types

let euroCallOption = EuropeanCall(100.0, DateTime(2026, 1, 16), "ABC")
let market =
    {
        Values = [ ("ABC", 101.0) ] |> Map.ofList
        ImpliedVols = [ ("ABC", 0.2) ] |> Map.ofList
        RiskFreeRate = 0.05
        ValuationDate = DateTime(2025, 12, 16)
    }

let price = Pricing.BlackScholes market euroCallOption
printfn "%f" price