namespace Forest.Types

open System

type Option =
        | EuropeanCall of strike: float * maturity: DateTime * underlying: string
        | EuropeanPut of strike: float * maturity: DateTime * underlying: string

type OptionMarketValues =
    {
        Spot: float
        ImpliedVol: float
    }

type Market =
    {
        Values: Map<string, float>
        ImpliedVols: Map<string, float>
        RiskFreeRate: float
        ValuationDate: DateTime
    }