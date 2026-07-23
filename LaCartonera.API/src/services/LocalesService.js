const Locales = require('../models/LocalesModel');

class LocalesService {

    async createLocales(data) {

        const Local = new Locales(data);

        await Local.save();
        return Local;

    }

    async getLocales(id) {

        if (id !=0) {
            return await Locales.findById(id);
        }
        return await Locales.find();

    }

    async updateLocales(id, data) {

        return await Locales.findByIdAndUpdate(id, data, { new: true });

    }

    async deleteLocales(id) {

        return await Locales.findByIdAndDelete(id);

    }

    async getLocalesWithResennas(id) {

        id = parseInt(id)

        const Local = await Locales.aggregate([
            {
                $match: { _id: id }
            },
            {
                $lookup: {
                    from: "Resennas",
                    localField: "_id",
                    foreignField: "id_local",
                    as: "Resennas"
                }
            }
        ]);

        return localStorage;

    }

    async getLocalWithReservas(id) {

        id = parseInt(id)

        const local = await Locales.aggregate([
            {
                $match: { _id: id }
            },
            {
                $lookup: {
                    from: "Reservas",
                    localField: "_id",
                    foreignField: "id_local",
                    as: "Reservas"
                }
            }
        ]);

        return local;

    }

}

module.exports = new LocalesService();
