import React, { Component } from 'react';
import axios from 'axios';

class SearchFrom extends Component {
    constructor(props) {
        super(props);

        this.state = {
            lat: 60,
            lon: 60,
            count: 50,
            radius: 5000,
            page: 1
        };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.search = this.search.bind(this);
    }

    handleInputChange(event) {
        const target = event.target;

        this.setState({
            [target.name]: target.value
        });
    }

    search(e) {
        e.preventDefault();

        var self = this;

        axios.post('/api/vk', {
            lat: this.state.lat,
            lon: this.state.lon,
            count: this.state.count,
            radius: this.state.radius,
            page: this.state.page
        })
        .then(function (response) {
            console.log(response.data);
            self.setState({ page: self.state.page + 1 });
        })
        .catch(function (error) {
            console.log(error);
        });
    }

    render() {
        return (
            <form onSubmit={this.search}>
                <p>
                    <label>Lat:</label><br />
                    <input type="number" name="lat" step="any" min="-90" max="90"
                        value={this.state.lat}
                        onChange={this.handleInputChange} />
                </p>
                <p>
                    <label>Lon:</label><br />
                    <input type="number" name="lon" step="any" min="-180" max="180"
                        value={this.state.lon}
                        onChange={this.handleInputChange} />
                </p>
                <p>
                    <label>Count:</label><br />
                    <input type="number" name="count" min="10" max="500"
                        value={this.state.count}
                        onChange={this.handleInputChange} />
                </p>
                <p>
                    <label>Radius:</label><br />
                    <input type="number" name="radius" min="1000" max="32000"
                        value={this.state.radius}
                        onChange={this.handleInputChange} />
                </p>
                <input type="submit" value="Search!" />
            </form>
        );
    }
}

export default SearchFrom;