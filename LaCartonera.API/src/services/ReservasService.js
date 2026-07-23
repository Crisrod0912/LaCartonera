const Reservas = require('../models/ReservasModel');

class ReservasService {

    async createReserva(data) {

        const Reserva = new Reservas(data);
        await Reserva.save();
        return Reserva;

    }

    async getReserva(id) {

        if (id !=='0') {
            return await Reservas.findById(id);
        }
        return await Reservas.find();

    }

    async updateReserva(id, data) {

        return await Reservas.findByIdAndUpdate(id, data, { new: true });

    }

    async deleteReserva(id) {

        return await Reservas.findByIdAndDelete(id);

    }

}

module.exports = new ReservasService();
