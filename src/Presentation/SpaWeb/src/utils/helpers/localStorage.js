const user = "user";

export const setUserInLocalStorage = (response) => {
  const data = response.data.data;
  console.log(response.data.data);
  const token = data.token;
  const balance = data.balance;
  const jwtParams = JSON.parse(atob(token.split(".")[1]));
  const id = jwtParams.id;
  const isAdmin = jwtParams.role?.toLowerCase().includes("admin");

  let dataToStore = {};
  dataToStore.id = id;
  dataToStore.balance = balance;
  dataToStore.isAdmin = isAdmin ?? false;

  localStorage.setItem(user, JSON.stringify(dataToStore));
  return dataToStore;
};

export const removeUserFromLocalStorage = () => localStorage.removeItem(user);

export const getUserFromLocalStorage = () =>
  JSON.parse(localStorage.getItem(user));

export const updateUserBalanceFromLocalStorage = (balance) => {
  const userData = JSON.parse(localStorage.getItem(user));
  userData.balance = balance;
  localStorage.setItem(user, JSON.stringify(userData));
}
 