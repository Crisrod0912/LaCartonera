const express = require('express');
const connectDB = require('./config/db');
const CategoriasRoutes = require('./routes/CategoriasRoutes');
const ContactoNegocioRoutes = require('./routes/ContactoNegocioRoutes');
const ContactoRoutes = require('./routes/ContactoRoutes');
const EventosEspecialesRoutes = require('./routes/EventosEspecialesRoutes');
const FotosRoutes = require('./routes/FotosRoutes');
const HorariosRoutes = require('./routes/HorariosRoutes');
const LocalesRoutes = require('./routes/LocalesRoutes');
const MenusRoutes = require('./routes/MenusRoutes');
const ResennasRoutes = require('./routes/ResennasRoutes');
const ReservasRoutes = require('./routes/ReservasRoutes');
const UbicacionesRoutes = require('./routes/UbicacionesRoutes');
const UsuariosRoutes = require('./routes/UsuariosRoutes');
const VistaResennasRoutes = require('./routes/VistaResennasRoutes');

const app = express();

connectDB();

app.use(express.json());

app.use('/LaCartonera.API', CategoriasRoutes);
app.use('/LaCartonera.API', ContactoNegocioRoutes);
app.use('/LaCartonera.API', ContactoRoutes);
app.use('/LaCartonera.API', EventosEspecialesRoutes);
app.use('/LaCartonera.API', FotosRoutes);
app.use('/LaCartonera.API', HorariosRoutes);
app.use('/LaCartonera.API', LocalesRoutes);
app.use('/LaCartonera.API', MenusRoutes);
app.use('/LaCartonera.API', ResennasRoutes);
app.use('/LaCartonera.API', ReservasRoutes);
app.use('/LaCartonera.API', UbicacionesRoutes);
app.use('/LaCartonera.API', UsuariosRoutes);
app.use('/LaCartonera.API', VistaResennasRoutes);

const PORT = process.env.PORT ?? 8760;
app.listen(PORT, () => console.log('El servidor se está ejecutando en el puerto: ', PORT));
