const mongoose = require('mongoose');
const dotenv = require('dotenv');

dotenv.config();

const connectDB = async () => {
    try {
        await mongoose.connect(process.env.databaseURL, {
        });
        console.log('MongoDB connected');
    } catch(err) {
        console.err(err.message);
        process.exit(1);
    }
};

module.exports = connectDB;
