const Resennas = require('../models/ResennasModel');

class ResennasService {

    async createResenna(data) {

        const resenna = new Resennas(data);
        await resenna.save();
        return resenna;

    }

    async getResenna(id) {

        if (id !=='0') {
            return await Resennas.findById(id);
        }
        return await Resennas.find();

    }

    async updateResenna(id, data) {

        return await Resennas.findByIdAndUpdate(id, data, { new: true });

    }

    async deleteResenna(id) {

        return await Resennas.findByIdAndDelete(id);

    }

}

module.exports = new ResennasService();
