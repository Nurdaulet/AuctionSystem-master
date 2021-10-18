import api from "../utils/helpers/api";

const getLastBalance = (userId) => {
  return api
      .get(`${process.env.REACT_APP_API_BALANCE_ENDPOINT}/getLastBalance/${userId}`)
      .then((response) => response);
};

export default { getLastBalance };
