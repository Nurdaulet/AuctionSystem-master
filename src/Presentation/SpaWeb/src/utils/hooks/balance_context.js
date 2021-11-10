import React, { useState, useEffect, useContext, createContext } from "react";
import { updateUserBalanceFromLocalStorage } from "../helpers/localStorage";
import { useAuth } from "../hooks/authHook";
import balanceService from "../../services/balanceService";



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
    //console.log(auth?.user);
    const [balance, setBalance] = useState(auth?.user?.balance);

    useEffect(() => {
        changeBalance();
      }, [auth]);

    const changeBalance = () => {
        if(!auth?.user)
            return;          
        balanceService.getLastBalance(auth?.user.id).then((response) => {
            const lastBalance = response.data.data?.saldo;       
            updateUserBalanceFromLocalStorage(lastBalance);
        setBalance(lastBalance);
            //console.log(response);
          });
    };

    return { balance, changeBalance };
}

export const useBalance = () => {
    return useContext(balanceContext);
};

