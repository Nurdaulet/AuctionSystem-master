import React, { useState, useEffect, useContext, createContext } from "react";
import { updateUserBalanceFromLocalStorage } from "../helpers/localStorage";
import { useAuth } from "../hooks/authHook";



const balanceContext = createContext();

export function ProvideBalance({ children }) {
    const balance = useProvideBalance();
    return (
        <balanceContext.Provider value={balance}>
            {children}
        </balanceContext.Provider>
    );
};

function useProvideBalance() {
    const auth = useAuth();
    console.log(auth?.user?.balance);
    const [balance, setBalance] = useState(auth?.user?.balance);

    // useEffect(() => {
    //     if(auth.user != null && balance != null){
    //         updateUserBalanceFromLocalStorage(balance);
    //     }
    //   }, [balance, auth]);
    const changeBalance = () => {
        setBalance(9999);
    };

    return { balance, changeBalance };
}

export const useBalance = () => {
    return useContext(balanceContext);
};

