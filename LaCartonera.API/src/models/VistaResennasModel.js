const mongoose = require('mongoose');
const VistaResennasSchema = new mongoose.Schema({

    _id: { type: Number, required: true },
    total_resennas: { type: Number, required: true },
    promedio_calificacion: { type: Number, required: true }

},

    { collection: 'vista_resumen_resennas' }

);

module.exports = mongoose.model('VistaResennas', VistaResennasSchema);
