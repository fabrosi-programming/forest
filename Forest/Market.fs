namespace Forest

open Forest.Types

module Market =
    let GetOptionMarketValues market option =
        let key =
            match option with
            | EuropeanCall(_, _, underlying) -> underlying
            | EuropeanPut(_, _, underlying) -> underlying

        {
            Spot = market.Values.[key]
            ImpliedVol = market.ImpliedVols.[key]
        }