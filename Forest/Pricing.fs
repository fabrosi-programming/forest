namespace Forest

open System
open FSharp.Stats
open Forest.Types

// Special characters: σ τ

module Pricing =
    let d_plus s k σ τ r =
        let num = Math.Log(s/k) + ((r + σ*σ/2.) * τ)
        let denom = σ * Math.Sqrt(τ)
        num / denom

    let d_minus s k σ τ r =
        (d_plus s k σ τ r) - (σ * Math.Sqrt(τ))

    let N x =
        Distributions.Continuous.Normal.CDF 0. 1. x

    let BlackScholes market option =
        let { Spot = s; ImpliedVol = σ } = Market.GetOptionMarketValues market option
        let r = market.RiskFreeRate

        match option with
        | EuropeanCall(k, maturity, _) ->
            let τ = (maturity - market.ValuationDate).TotalDays / 365.
            let d_plus = d_plus s k σ τ r
            let d_minus = d_minus s k σ τ r
            N(d_plus)*s - N(d_minus)*k*Math.Exp(-r*τ)
        | EuropeanPut(k, maturity, _) ->
            let τ = (maturity - market.ValuationDate).TotalDays / 365.
            let d_plus = d_plus s k σ τ r
            let d_minus = d_minus s k σ τ r
            N(-d_minus)*k*Math.Exp(-r*τ) - N(-d_plus)*s