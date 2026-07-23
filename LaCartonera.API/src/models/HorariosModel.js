const mongoose = require('mongoose');
const HorariosSchema = new mongoose.Schema({

    _id: { type: Number },
    id_restaurante: { type: Number, ref : 'Locales' },
    dia_semana: { 
        type: String,
        enum: ['Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado', 'Domingo'],
        required: true 
    },
    hora_apertura: { type: String },
    hora_cierre: { type: String },
    cierre_por_ocasion_especial: { type: Boolean }

},

    { collection: 'Horarios' }

);

module.exports = mongoose.model('Horarios', HorariosSchema)
