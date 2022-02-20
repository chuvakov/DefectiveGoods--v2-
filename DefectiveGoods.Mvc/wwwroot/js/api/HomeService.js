import axios from "./../../lib/axios/axios"

export default class HomeService {

    static async getProducts(filter) {
        const response = await axios.post("/Home/GetProducts", filter);
        return response;
    }
}