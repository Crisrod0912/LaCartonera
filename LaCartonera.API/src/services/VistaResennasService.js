const mongoose = require('mongoose');
const VistaResenna = require('../models/VistaResennasModel');
const Resenna = require('../models/ResennasModel');

class VistaResennasService {

    async getVistaResennas() {

        try {
            const resennas = await VistaResenna.find();
            return resennas;
        } catch (err) {
            throw new Error('Error al obtener la vista materializada: ' + err.message);
        }

    }

    async actualizarVistaMaterializada() {

        const pipeline = [
            {
                $group: {
                    _id: "$id_local",
                    total_resennas: { $sum: 1 },
                    promedio_calificacion: { $avg: "$calificacion" }
                }
            },
            {
                $out: "vista_resumen_resennas"
            }
        ];

        try {
            await Resenna.aggregate(pipeline);
            console.log("Vista materializada actualizada.");
        } catch (err) {
            throw new Error('Error al actualizar la vista materializada: ' + err.message);
        }

    }

}

module.exports = new VistaResennasService();
